using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrExitDoor : MonoBehaviour
{
    public bool hasKey = false;
    string currentSceneName;

    private void Update()
    {
        if (GameObject.Find("KeyPlayer") != null)
        { hasKey = true; }
        currentSceneName = SceneManager.GetActiveScene().name;
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
                    }
                }
                break;
        }
    }
    public void WinScene()
    {
        if (currentSceneName == "Level1")
        { SceneManager.LoadScene("GameOver"); }
        if (currentSceneName == "Level2")
        { SceneManager.LoadScene("GameOver2"); }
    }
}