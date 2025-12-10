using UnityEngine;

public class scrZombie : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    public AudioSource audioSource;
    public AudioClip screamSound;

    // --- Added variables ---
    public float stunDuration = 2f;        // how long zombie pauses after hitting player
    private bool isStunned = false;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (isStunned) return; // pause movement if stunned

                speed = 1;
                Vector3 targetPos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                Vector3 playerlook = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.LookAt(playerlook);

                //audioSource.PlayOneShot(screamSound);
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        speed = 0;
    }

    // --- Added: pause when zombie first hits player ---
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StunZombie());
        }
    }

    private System.Collections.IEnumerator StunZombie()
    {
        isStunned = true;
        speed = 0;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
