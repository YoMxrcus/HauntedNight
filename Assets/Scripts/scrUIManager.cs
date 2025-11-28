// UIManager.cs (Attach to your Battery Bar GameObject)
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // A globally accessible static reference to THIS instance
    public static UIManager Instance { get; private set; }

    // The Slider component you want other scripts to access
    [SerializeField] private Slider batteryBar;

    private void Awake()
    {
        // 1. Establish the Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // A public method for other scripts to call
    public void UpdateFlashlightBattery(float currentAmount)
    {
        batteryBar.value = currentAmount;
    }
}