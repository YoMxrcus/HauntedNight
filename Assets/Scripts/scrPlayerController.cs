using NUnit.Framework;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class scrPlayerController : MonoBehaviour
{
    //Stamina Variables
    public float stamina = 100;
    public Slider staminaBar;

    //Health Variables
    public int health = 100;
    public Slider healthBar;

    //Audio Variables
    public AudioSource sound;
    public AudioClip sprintSound;
    public AudioClip flashlightSound;

    //Backpack Variables
    public GameObject flashlightPNG;
    public GameObject keyPNG;
    public GameObject inventoryPAN;
    public GameObject battery;

    public GameObject panGameOver;

    //player objects
    public GameObject flashlightPlayer, keyPlayer;

    // Battery
    public float batteryAmount = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) & stamina > 0)
        {
            GetComponent<scrPlayerMovement>().speed = 6;
            stamina -= 0.2f;
            UpdateData();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sound.clip = sprintSound;
            sound.loop = true;
            sound.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sound.Stop();
            GetComponent<scrPlayerMovement>().speed = 3;
            UpdateData();
        }
        else if (stamina < 100f)
        {
            stamina += 0.1f;
            UpdateData();
        }
        if (stamina < 5)
        {
            sound.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPAN.SetActive(true);
            PauseMenus();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInventory();
        }
    }
    public void EquipFlashlight()
    {
        ExitInventory();
        keyPlayer.SetActive(false);
        flashlightPlayer.SetActive(true);
        // Sets all images to false
        foreach (Image image in GameObject.Find("BatteryBar").GetComponentsInChildren<Image>())
        {
            image.enabled = true;
        }
    }
    public void EquipKey()
    {
        ExitInventory();
        flashlightPlayer.SetActive(false);
        keyPlayer.SetActive(true);
        
        // Sets all images to false
        foreach (Image image in GameObject.Find("BatteryBar").GetComponentsInChildren<Image>())
        {
            image.enabled = false;
        }
    }
    void PauseMenus()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ExitInventory()
    {
        inventoryPAN.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UpdateData()
    {
        staminaBar.value = stamina;
        healthBar.value = health;
        if (health <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
    public void MainMenuBTN()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "enemy":
                health -= 10;
                UpdateData();
                break;
            case "flashlight":
                flashlightPNG.SetActive(true);
                Destroy(other.gameObject);
                break;
            case "key":
                keyPNG.SetActive(true);
                Destroy(other.gameObject);
                break;
            case "battery":
                Destroy(other.gameObject);
                batteryAmount += 25;

                if (UIManager.Instance != null)
                {
                    UIManager.Instance.UpdateFlashlightBattery(batteryAmount);
                }
                break;

        }
    }
}
