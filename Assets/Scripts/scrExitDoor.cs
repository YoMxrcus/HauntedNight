using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrExitDoor : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip exitSound;
    public bool hasKey = false;

    private void Update()
    {
        if (GameObject.Find("KeyPlayer") != null)
        { hasKey = true; }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                {
                    if (hasKey)
                    {
                        Invoke("WinScene", 1f);
                        sound.PlayOneShot(exitSound);
                        
                    }
                }
                break;
        }
    }
    public void WinScene()
    {
        SceneManager.LoadScene("Win");
    }
}