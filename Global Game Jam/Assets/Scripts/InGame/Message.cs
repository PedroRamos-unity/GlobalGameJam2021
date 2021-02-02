using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    private float timer;
    private float messageTime = 6f;

    [SerializeField]
    private GameObject canotCarryMessage = null;
    void Start()
    {
        DisplayCanotCarryMessage();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(canotCarryMessage.activeSelf && timer >= messageTime )
        {
            NotDisplayCanotCarryMessage();
        }


    }



    public void DisplayCanotCarryMessage()
    {

        canotCarryMessage.SetActive(true);
        timer = 0f;
       
        

    }

    public void NotDisplayCanotCarryMessage()
    {
        canotCarryMessage.SetActive(false);
    }



}
