using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{ 

    [SerializeField]
    private AudioSource mixer = null;

    [SerializeField]
    private GameObject menu = null;

    [SerializeField]
    private GameObject optionsMenu = null;

    public bool isPaused = false;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    private void Update()
    {
        OpenMenu();


        if(isPaused)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

    }


    private void OpenMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            isPaused = true;
            menu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        isPaused = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenOptionsMenu()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetVolume(float sliderValue)
    {
        mixer.volume = sliderValue;
    }


    public void Lost()
    {
        SceneManager.LoadSceneAsync(3);
    }


}
