using UnityEngine;

public class scrDoor : MonoBehaviour
{
    public Vector3 endPos;
    public AudioSource sound;
    public AudioClip doorSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    Vector3 endPos = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
                    transform.position = endPos;
                    sound.PlayOneShot(doorSound);
                    GetComponent<MeshRenderer>().enabled = true;
                }
                break;
        }
    }
}
