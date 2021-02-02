using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameManager gm = null;

    [SerializeField]
    private CharacterController controller = null;

    private float speed = 4f;

    private float gravity = -9.8f;
    private float jumpForce = 2.6f;

    Vector3 velocity;
    [SerializeField]
    private Animator anim = null;

    [SerializeField]
    private Transform groundCheck;

    public float groundDistance = 0.5f;

    [SerializeField]
    private LayerMask layerGround;

    private bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        if(!gm.isPaused)
        {
            GroundCheck();
            Movement();
        }

  
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime ;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        if(x != 0 || z != 0 && isGrounded)
        {
            
            anim.SetBool("Walking", true);
        }
        else
        {
            
            anim.SetBool("Walking", false);
        }

        Sprint();

    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layerGround);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    private void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 7;
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
            speed = 4;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gm.Lost();
        }
    }


}
