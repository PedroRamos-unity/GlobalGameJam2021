using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource enemySound = null;

    [SerializeField]
    private AudioClip[] clip = null;

    private AudioSource characterSound;

    void Start()
    {
        characterSound = gameObject.GetComponent<AudioSource>();
        characterSound.Play();
    }

    public void PickUpSound()
    {
        characterSound.PlayOneShot(clip[0]);
    }

    public void SwitchSound()
    {
        characterSound.PlayOneShot(clip[1]);
    }

    public void EnemyMusic()
    {
        characterSound.PlayOneShot(clip[3]);
        characterSound.volume = 0.2f;
        
    }


    public void EnemyBite()
    {
        enemySound.Play();
    }

}
