using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public int levels;
    public GameObject panTransition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //panTransition.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartBtn()
    {
        panTransition.SetActive(true);
        Invoke("LoadLevelOne", 5);

    }
    public void HelpBtn()
    {
        SceneManager.LoadScene("Help");
    }
    public void OptionsBtn()
    {
        SceneManager.LoadScene("Options");
    }
    public void Lvl1_OptionsBtn()
    {
        SceneManager.LoadScene("Options");
    }
    public void Lvl2_OptionsBtn()
    {
        SceneManager.LoadScene("Options");
    }
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseBackBtn()
    {

        SceneManager.LoadScene("Level1");
    }
    public void PauseBackBtn2()
    {

        SceneManager.LoadScene("Level2_cleaned");
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
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Lvl2_RetryBtn()
    {
        SceneManager.LoadScene("Level2_cleaned");
        Time.timeScale = 1;
    }
    public void Continue() 
    {
        ToLevelTwo();
        Time.timeScale = 1;
    }
    public void LoadLevelOne()
    {
        Debug.Log("Load");
        SceneManager.LoadScene("Level1");
        Debug.Log("Loaded");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
        public void ToLevelTwo()
    {
        panTransition.SetActive(true);
        Invoke("LoadLevel2", 5);
    }
}
