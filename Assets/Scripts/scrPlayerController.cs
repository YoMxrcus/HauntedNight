using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;

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

    //Backpack Variables
    public GameObject rosaryPNG, rosary;
    public GameObject flashlightPNG, flashlight;
    public GameObject battery;
    public GameObject batteryBar;
    float batteryAmount = 100;
    public GameObject keyPNG, key;
    public GameObject inventoryPAN;

    //Pickup Variables
    public Transform playerCameraTransform;
    private GameObject currentEquippedItem = null; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) & stamina > 0)
        {
            GetComponent<scrPlayerMovement>().speed = 6;
            stamina-= 0.3f;
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPAN.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitInventory();
        }
    }
    public void EquipFlashlight()
    {
        ExitInventory();
        PickUpHandler(flashlight, new Vector3(4.5f, 4.5f, 4.5f), Quaternion.Euler(90f, 90f, 90f));
    }
    public void EquipKey()
    {
        ExitInventory();
        PickUpHandler(key, new Vector3(4.5f, 4.5f, 4.5f), Quaternion.Euler(90f, 0f, 90f));
    }
    void PickUpHandler(GameObject pickup, Vector3 scale, Quaternion rotation)
    {
        if (currentEquippedItem != null)
        {
            Destroy(currentEquippedItem);
            currentEquippedItem = null;
        }
        GameObject newPickup = Instantiate(pickup);
        currentEquippedItem = newPickup;

        newPickup.transform.parent = playerCameraTransform;
        newPickup.transform.localPosition = new Vector3(.5f, -.25f, .75f);
        newPickup.transform.localScale = scale;
        newPickup.transform.localRotation = rotation;
    }
    void ExitInventory()
    {
        inventoryPAN.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UpdateData()
    {
        staminaBar.value = stamina;
        healthBar.value = health;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "enemy":
                health -= 10;
                UpdateData();
                break;
            case "rosary":
                rosaryPNG.SetActive(true);
                Destroy(other.gameObject);
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
                break;


        }

    }
}
