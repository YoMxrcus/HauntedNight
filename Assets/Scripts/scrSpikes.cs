using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    // Assign these in the Inspector
    public Transform startPos;
    public Transform endPos;
    // Control the speed of the movement (adjust this float in the inspector to tune speed)
    public float speed = 1.5f;

    // No Update() needed for movement with PingPong, it works well in Start/Awake for initial positioning

    private void Start()
    {
        // Ensure the object starts at one of the defined positions
        if (startPos != null)
        {
            transform.position = startPos.position;
        }
    }

    void Update()
    {
        if (startPos == null || endPos == null)
        {
            Debug.LogError("StartPos or EndPos not assigned for SpikeTrap!");
            return;
        }

        // Calculate a 't' value that bounces smoothly between 0 and 1 over time
        // The speed variable controls how fast this bounce happens
        float t = Mathf.PingPong(Time.time * speed, 1.0f);

        // Interpolate the position between startPos and endPos using the bouncing 't' value
        transform.position = Vector3.Lerp(startPos.position, endPos.position, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player touched spikes and died!");
            // Make sure you have a scene named "GameOver" in your build settings
            SceneManager.LoadScene("GameOver");
        }
    }
}
