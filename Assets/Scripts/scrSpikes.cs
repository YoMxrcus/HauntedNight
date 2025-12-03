using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class SpikeTrap : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;
    bool endGoal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player when they touch the spikes
            Destroy(other.gameObject);

            // Log to console
            Debug.Log("Player touched spikes and died!");

            // Load the death scene (make sure it's added to Build Settings)
           // SceneManager.LoadScene("DeathScene");
        }
    }
    private void Start()
    {
        transform.position = startPos;
    }
    private void Update()
    {
        if (transform.position == startPos)
        {
            endGoal = false;
        }
        else if (transform.position == endPos)
        {
            endGoal = true;
        }
    }
    private void FixedUpdate()
    {
        if (!endGoal)
        {
            GoToEnd();
        }
        else
        {
            GoToStart();
        }
    }
    void GoToEnd()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, .25f);
    }
    void GoToStart()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, .25f);
    }
}

