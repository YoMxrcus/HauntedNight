using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scrPlayerController : MonoBehaviour
{
    public float stamina = 100;
    public Slider staminaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stamina-= 0.25f;
            UpdateData();
        }
        else
        {
            stamina += 0.1f;
        }
    }
    void UpdateData()
    {
        staminaBar.value = stamina;
    }
}
