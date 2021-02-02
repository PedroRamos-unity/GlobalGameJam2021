using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    [SerializeField]
    private AudioSource sound = null;

    [SerializeField]
    private AudioClip biter = null;

    public void BiteSound()
    {
        sound.PlayOneShot(biter);
        
    }

}
