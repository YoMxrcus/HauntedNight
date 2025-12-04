using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player when they touch the spikes
            Destroy(other.gameObject);

            // Log to console
            Debug.Log("Player touched spikes and died!");

            // Load the death scene (make sure it's added to Build Settings)
            SceneManager.LoadScene("DeathScene");
        }
    }
}

