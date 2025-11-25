using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System.Collections;

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
    public GameObject testOBJ;

    //Pickup Variables
    GameObject testPickup;
    GameObject player;

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
