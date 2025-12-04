using UnityEngine;

public class scrGhost : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    public AudioSource audioSource;
    public AudioClip alertSound;
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
                speed = 1;
                Vector3 targetPos = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                Vector3 playerlook = new Vector3(target.position.x, transform.position.y, target.position.z);
                transform.LookAt(playerlook);

                audioSource.PlayOneShot(alertSound);

                break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        speed = 0;
    }
}