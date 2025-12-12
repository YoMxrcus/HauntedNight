using UnityEngine;

public class BoulderController : MonoBehaviour
{

    public Transform player;          // Assign your player transform in Inspector
    private Rigidbody rb;


    public float detectionRange = 20f; // How close the player must be
    private bool playerInRange = false;


    public float rollForce = 150;     // Initial push downhill
    public float chaseForce = 10;     // Force applied toward player
    public float maxSpeed = 10f;       // Cap speed

    public string wallTag = "BreakableWall"; // Tag for the specific wall
    public string playerTag = "Player";      // Tag for player object

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Boulder starts idle until triggered
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < detectionRange)
        {
            playerInRange = true;
            ActivateBoulder();
            ChasePlayer();
        }
        else
        {
            playerInRange = false;
        }
    }

    void ActivateBoulder()
    {
        if (!rb.useGravity)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.down * rollForce, ForceMode.Impulse);
        }
    }

    void ChasePlayer()
    {
        if (!playerInRange) return;

        Vector3 chaseDir = (player.position - transform.position).normalized;
        rb.AddForce(chaseDir * chaseForce);

        // Clamp velocity
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the boulder hits the specific wall, destroy it
        if (collision.gameObject.CompareTag(wallTag))
        {
            Destroy(collision.gameObject);
        }
    }
}