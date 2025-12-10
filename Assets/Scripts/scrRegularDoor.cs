using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Removed Unity.VisualScripting; if not used, it's cleaner

public class scrRegularDoor : MonoBehaviour
{
    // Make these public and assign them in the Unity Inspector
    public GameObject inventoryPan;
    public GameObject keyPNG;
    public GameObject keyPlayer; // Assuming this is the key object in the player's possession

    public bool hasKey = false;

    // Use Awake or Start to initialize things if you must use Find, but Inspector is better
    void Start()
    {
        
        inventoryPan = GameObject.Find("InventoryPan");
        keyPNG = GameObject.Find("keyPNG");
        keyPlayer = GameObject.Find("KeyPlayer");
        if (GameObject.Find("KeyPlayer"))
        { hasKey = true;}
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("key")) // Safer way to check tags
        {       
            Destroy(gameObject); // Destroys the door
            keyPlayer.SetActive(false);
            //inventoryPan.SetActive(true);
            keyPNG.SetActive(false);
            //inventoryPan.SetActive(false);
            hasKey = false;
        }
    }
}
