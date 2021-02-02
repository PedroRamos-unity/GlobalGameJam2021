using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    private Character cc;

    [SerializeField]
    private AudioSource footstep = null;

    [SerializeField]
    private AudioClip clip = null;

    private void Start()
    {
        cc = gameObject.GetComponent<Character>();
    }


    private void Update()
    {
        
    }


    public void FootstepWalk()
    {
        footstep.volume = Random.Range(0.4f, 0.6f);
        footstep.PlayOneShot(clip);
    }

    public void FootstepRun()
    {
        footstep.volume = Random.Range(0.6f, 1f);
        footstep.PlayOneShot(clip);
    }




}
