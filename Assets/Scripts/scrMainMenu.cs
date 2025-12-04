using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public int levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("Level1");
    }
    public void HelpBtn()
    {
        SceneManager.LoadScene("Help");
    }
    public void OptionsBtn()
    {
        SceneManager.LoadScene("Options");
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void ReturnToMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void RetryBtn()
    {
        if (levels == 0)
        {
            Debug.Log("Retrying Level 1");
        }
        if (levels == 1)
        {
            Debug.Log("Retrying Level 2");
        }
        Time.timeScale = 1;
    }
    public void Continue() 
    {
        if(levels == 0)
        {
            SceneManager.LoadScene("Level1");
        }
        if (levels == 1) 
        {
            SceneManager.LoadScene("Level1");
        }
        Time.timeScale = 1;
    }


}
