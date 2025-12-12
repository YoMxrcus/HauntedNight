using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;


public class scrFlashlight : MonoBehaviour
{
    // Flashlight Variables
    public GameObject lightBulb;
    bool isOn;

    // NEW: Depletion Rate (Units per second)
    public float batteryDepletionRate = 1f;

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
            // ... (Flashlight toggle and sound logic remains the same)
            sound.PlayOneShot(flashlightSound);
            isOn = !isOn; // Simplified toggle
            lightBulb.SetActive(isOn);
        }

        // Only run depletion logic if the flashlight is on
        if (isOn)
        {
            // **THE FIX:** Multiply the depletion rate by Time.deltaTime
            player.batteryAmount -= batteryDepletionRate * Time.deltaTime;

            // Ensure battery doesn't go negative
            player.batteryAmount = Mathf.Max(player.batteryAmount, 0f);

            if (UIManager.Instance != null)
            {
                UIManager.Instance.UpdateFlashlightBattery(player.batteryAmount);
            }

            // Turn off if battery hits zero
            if (player.batteryAmount <= 0)
            {
                lightBulb.SetActive(false);
                isOn = false;
            }
        }
    }
}