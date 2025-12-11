using Unity.VisualScripting;
using UnityEngine;

public class scrBolderDrop : MonoBehaviour
{
    public GameObject bolder;
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
                    Invoke("SpawnBolder", 1);
                }
                break;
        }
    }
    public void SpawnBolder()
    {
        bolder.SetActive(true);
    }
}
