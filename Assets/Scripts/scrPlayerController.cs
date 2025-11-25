using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class scrPlayerController : MonoBehaviour
{
    //Stamina Variables
    public float stamina = 100;
    public Slider staminaBar;
    bool isSprinting;

    public int health = 100;

    //Audio Variables
    public AudioSource sound;
    public AudioClip sprintSound;



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
            isSprinting = true;
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
        }
        else if (stamina < 100f)
        {
            GetComponent<scrPlayerMovement>().speed = 3;
            stamina += 0.1f;
            UpdateData();
        }
    }
    void UpdateData()
    {
        staminaBar.value = stamina;
    }
}
