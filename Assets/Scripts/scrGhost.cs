using UnityEngine;

public class scrGhost : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); transform.LookAt(target);
        }
    }
    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                speed = 1;
                transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
                break;
        }
    }
    void OnTriggerExit(Collider other)
    {
        speed = 0;
    }
}