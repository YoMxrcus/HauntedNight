using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;


public class scrFlashlight : MonoBehaviour
{
    //Flashlight Variables
    public GameObject lightBulb;
    bool isOn;

    public AudioSource sound;
    public AudioClip flashlightSound;

    public scrPlayerController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            sound.PlayOneShot(flashlightSound);
            if (isOn)
            {
                lightBulb.SetActive(false);
                isOn = false;
            }
            else
            {
                lightBulb.SetActive(true);
                isOn = true;
            }
        }
        if (isOn)
        {
            player.batteryAmount -= 0.005f;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateFlashlightBattery(player.batteryAmount);
            }
            if (player.batteryAmount <= 0)
            {
                lightBulb.SetActive(false);
                isOn = false;
            }
        }
    }
}
