using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPost : MonoBehaviour
{
    [SerializeField]
    private Character character = null;

    private bool isPlayerNearby;

    [SerializeField]
    private Lantern lantern = null;

    [SerializeField]
    private LayerMask layer;

    public bool playerSafe = false;

    Vector3 boxSize = new Vector3(5f, 3f, 5f);

    void Start()
    {
        
    }

    void Update()
    {
        CheckPlayer();
    }


    private void CheckPlayer()
    {
        isPlayerNearby = Physics.CheckBox(transform.localPosition, boxSize, Quaternion.identity, layer);

        if (isPlayerNearby )
        {
            playerSafe = true;
           
            if(lantern.enemyNearby)
            {
                lantern.enemyNearby = false;
            }      
        }
        else if(!isPlayerNearby)
        {
            playerSafe = false;
        }

    }


}
