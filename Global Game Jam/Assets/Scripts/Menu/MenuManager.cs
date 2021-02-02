using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{


    [SerializeField]
    private AudioSource sound = null;

    [SerializeField]
    private GameObject menuScreen = null;

    [SerializeField]
    private GameObject optionsScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume(float sliderValue)
    {
        sound.volume = sliderValue;
    }

    public void Options()
    {
        optionsScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void BackToMenu()
    {
        optionsScreen.SetActive(false);
        menuScreen.SetActive(true);
    }


}
