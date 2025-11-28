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
    public Slider batteryBar;
    bool isOn;
    public float batteryAmount = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
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
            batteryAmount -= 0.005f;
            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateFlashlightBattery(batteryAmount);
            }
            if (batteryAmount <= 0)
            {
                lightBulb.SetActive(false);
                isOn = false;
            }
        }
    }
}
