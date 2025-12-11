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
    string currentSceneName;

    //Stamina Variables
    public float stamina = 100;
    public Slider staminaBar;
    public GameObject highEnergy, mediumEnergy, lowEnergy;

    //Health Variables
    public int health = 100;
    public Slider healthBar;
    public GameObject highHealth, mediumHealth, lowHealth;

    //Audio Variables
    public AudioSource sound;
    public AudioSource sprint;
    public AudioClip sprintSound;
    public AudioClip healthSound;
    public AudioClip zombieAttackSound;
    public AudioClip ghoulAttackSound;
    public AudioClip coughSound;
    public AudioClip flashlightSound;
    public AudioClip batteryPickup;
    public AudioClip pickupSound;

    //Backpack Variables
    public GameObject flashlightPNG;
    public GameObject keyPNG;
    public GameObject inventoryPAN;
    public GameObject battery;
    public GameObject pausePanel;

    //player objects
    public GameObject flashlightPlayer, keyPlayer;

    // Battery
    public float batteryAmount = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        sound = GetComponent<AudioSource>();
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) & stamina > 0)
        {
            GetComponent<scrPlayerMovement>().speed = 6;
            stamina -= 0.1f;
            UpdateData();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint.clip = sprintSound;
            sprint.loop = true;
            sprint.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint.Stop();
            GetComponent<scrPlayerMovement>().speed = 3;
            UpdateData();
        }
        else if (stamina < 100f)
        {
            stamina += 0.05f;
            UpdateData();
        }
        if (stamina < 5)
        {
            sprint.Stop();
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
            if(currentSceneName == "Level1")
            {SceneManager.LoadScene("GameOver");}
            if(currentSceneName == "Level2")
            {SceneManager.LoadScene("GameOver2");}
            
        }
        if (health <= 100)
        {
            highHealth.SetActive(true);
            mediumHealth.SetActive(false);
            lowHealth.SetActive(false);
        }
        if (health <= 50)
        {
            mediumHealth.SetActive(true);
            highHealth.SetActive(false);
            lowHealth.SetActive(false);
        }
        if (health <= 25)
        {
            lowHealth.SetActive(true);
            mediumHealth.SetActive(false);
            highHealth.SetActive(false);
        }

        if (stamina <= 100)
        {
            highEnergy.SetActive(true);
            mediumEnergy.SetActive(false);
            lowEnergy.SetActive(false);
        }
        if (stamina <= 50)
        {
            mediumEnergy.SetActive(true);
            highEnergy.SetActive(false);
            lowEnergy.SetActive(false);
        }
        if (stamina <= 25)
        {
            lowEnergy.SetActive(true);
            mediumEnergy.SetActive(false);
            highEnergy.SetActive(false);
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
    public void PauseBtn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeBtn()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Zombie":
                health -= 10;
                sound.PlayOneShot(zombieAttackSound);
                UpdateData();
                break;
            case "RollingBall":
                health -= 100;
                UpdateData();
                break;
            case "Ghost":
                health -= 10;
                sound.PlayOneShot(ghoulAttackSound);
                UpdateData();
                break;
            case "flashlight":
                flashlightPNG.SetActive(true);
                Destroy(other.gameObject);
                break;
            case "key":
                keyPNG.SetActive(true);
                sound.PlayOneShot(pickupSound);
                Destroy(other.gameObject);
                break;
            case "battery":
                Destroy(other.gameObject);
                batteryAmount += 25;
                sound.PlayOneShot(batteryPickup);

                if (UIManager.Instance != null)
                {
                    UIManager.Instance.UpdateFlashlightBattery(batteryAmount);
                }
                break;
            case "Spikes":
                health -= 100;
                UpdateData();
                break;
            case "Health":
                if(health < 100)
                {
                   health += 25;
                }
                Destroy(other.gameObject);
                sound.PlayOneShot(healthSound);
                UpdateData();
                break;
            case "Smoke":
                health -= 5;
                sound.PlayOneShot(coughSound);
                UpdateData();
                break;



        }
    }
}
