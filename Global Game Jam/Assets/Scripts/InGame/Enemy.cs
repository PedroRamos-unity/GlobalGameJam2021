using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private LampPost lamp = null;

    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private GameManager gm = null;

    [SerializeField]
    private SoundManager sound = null;

    [SerializeField]
    private Character character = null;

    [SerializeField]
    private Transform Runing = null;

    public enum State
    {
        PATROL,
        FOLLOW,
        RUNAWAY
    }

    private State state;

    [SerializeField]
    private Lantern lantern = null;

    [SerializeField]
    private LayerMask layer;  

    private float timer;
    private float wanderTime = 3f;

    public float lookRadius;

    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private NavMeshAgent agent;


    private float miniumRange = 35f;
    private float maximumRange = 45f;

    private float maximumRangeSqr;
    private float minimumRangeSqr;


    private void Start()
    {
        state = State.PATROL;
        timer = wanderTime;
        

        InvokeRepeating("Teleport", 5, 10);


        minimumRangeSqr = miniumRange * miniumRange;
        maximumRangeSqr = maximumRange * maximumRange;
        

    }


    void Update()
    {
        if(!gm.isPaused)
        {
            Behavior();
            LookAt();
            
        }

        
    }
   
    
    private void Behavior()
    {
       switch (state)
        {
            case State.FOLLOW:
                Follow();
                Debug.Log("Follow");
                
                break;
            case State.PATROL:
                Patrol();
                Debug.Log("Patrol");
                break;
            case State.RUNAWAY:
                RunAway();
                Debug.Log("RunAway");
                break;
                
        }
    }


    private void RunAway()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        transform.position = Runing.position;
        if(distance > lookRadius)
        {
            state = State.PATROL;
        }
          
    }

    
    private void Follow()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);
        
         if (distance <= lookRadius && lamp.playerSafe)
        {
            state = State.RUNAWAY;
        }

        if (distance >= lookRadius)
        {
            
            anim.SetBool("IsFollowing", false);
            state = State.PATROL;
        }
        


    }

    private void Patrol()
    {
        timer += Time.deltaTime;

        if(timer >= wanderTime)
        {
           Vector3 newPos = RandomNavSphere(transform.position, 50f, -1);
            agent.SetDestination(newPos);
            timer = 0f;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius && !lamp.playerSafe)
        {
            anim.SetBool("IsFollowing", true);
            lantern.enemyNearby = true;
            state = State.FOLLOW;
            

        }
        else if(distance > lookRadius)
        {
            anim.SetBool("IsFollowing", false);
        }

    }


    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
    
        NavMeshHit navhit;

        NavMesh.SamplePosition(randDirection, out navhit, dist, layermask);

        return navhit.position;

    }

    private void Teleport()
    {
        
        if (state != State.FOLLOW && state != State.RUNAWAY && !gm.isPaused) 
        {
            
            
            float teleportDistance = miniumRange;

            float rndDir = Random.Range(0, 2);

            if(rndDir ==0)
            {
                rndDir = -1;
            }

            Vector3 terrainPosCheck = target.position + (rndDir * target.right * miniumRange);
            terrainPosCheck.y = 5000.0f;

            RaycastHit hit;
            if(Physics.Raycast (terrainPosCheck, -Vector3.up, out hit, Mathf.Infinity))
            {
                if(hit.collider.name == "Terrain")
                {
                    transform.position = hit.point + new Vector3(0, 0.25f, 0);
                }
            }

        }
    }


    private void LookAt()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, 0, -direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

}
