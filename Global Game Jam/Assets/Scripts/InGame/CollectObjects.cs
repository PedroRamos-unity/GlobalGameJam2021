using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{

    [SerializeField]
    private SoundManager soundManager = null;

    [SerializeField]
    private ItemManager item = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractRaycast();
    }

   
    private void InteractRaycast()
    {

        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float distance = 4f;
        RaycastHit hit;

        if(Physics.Raycast(origin,direction, out hit, distance))
        {
            if(hit.transform.tag == "Collectable" && Input.GetKeyDown(KeyCode.E))
            {
                soundManager.PickUpSound();
                if(hit.transform.gameObject.layer == 10)
                {
                    item.CollectItens(10);
                    hit.transform.gameObject.SetActive(false);
                    
                }
                if(hit.transform.gameObject.layer == 11)
                {
                    item.CollectItens(11);
                    hit.transform.gameObject.SetActive(false);
                }
                if(hit.transform.gameObject.layer == 12)
                {
                    item.CollectItens(12);
                    hit.transform.gameObject.SetActive(false);
                }


            }
        }
    }




}
