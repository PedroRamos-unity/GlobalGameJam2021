using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{
    private AudioSource sound;

        
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }


    public void StartSound()
    {
        sound.Play();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
