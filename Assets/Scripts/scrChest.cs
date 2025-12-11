using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class scrChest : MonoBehaviour
{
    public float interactDistance = 2f;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
           
        }
    }
}
