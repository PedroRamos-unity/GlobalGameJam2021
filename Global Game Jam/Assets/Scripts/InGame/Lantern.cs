using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField]
    private GameManager gm = null;

    [SerializeField]
    private SoundManager sound = null;

    [SerializeField]
    private Light luz = null;

    public bool enemyNearby;

    private bool lanternSwitch = true;

    void Update()
    {
        if(!gm.isPaused)
        {
            Blinking();

            LanternLight();

            SwitchOnOff();

            if (enemyNearby)
            {
                StartCoroutine(Blinking());
            }
        }

    }

    private void LanternLight()
    {
        if (Input.GetButtonDown("Fire1") && lanternSwitch)
        {
            sound.SwitchSound();
            luz.intensity = 0;
            lanternSwitch = false;
        }
        else if (Input.GetButtonDown("Fire1") && !lanternSwitch)
        {
            sound.SwitchSound();
            lanternSwitch = true;
            luz.intensity = 3;
        }
    }

    IEnumerator Blinking()
    {
        while(enemyNearby)
        {
            lanternSwitch = !lanternSwitch;

            yield return new WaitForSeconds(Random.Range(4,7));
        }   
    }

    private void SwitchOnOff()
    {
        if(lanternSwitch)
        {
            luz.intensity = 3;
        }

        if (!lanternSwitch)
        {
            luz.intensity = 0;
        }
    }

}
