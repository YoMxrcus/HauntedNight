using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Collections;
using NUnit.Framework;

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
    public GameObject backpackBTN;
    public GameObject testOBJ, testCube;
    public GameObject inventoryPAN;


    //Pickup Variables
    public Transform playerCameraTransform;
    bool hasTest;


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
            inventoryPAN.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void Equipped()
    { 
        inventoryPAN.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (testOBJ & !hasTest)
        {
            GameObject testObject = Instantiate(testCube);
            testObject.transform.parent = playerCameraTransform;
            testObject.transform.localPosition = new Vector3(.5f, -.25f, .75f);
            testObject.transform.localScale = new Vector3(.25f, .25f, .25f);
            testObject.transform.localRotation = Quaternion.identity;
            hasTest = true;
        }
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

            case "pickup":
                testOBJ.SetActive(true);
                Destroy(other.gameObject);
                break;

        }

    }
}
