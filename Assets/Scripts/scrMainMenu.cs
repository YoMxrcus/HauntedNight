using System.Collections;
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

        StartCoroutine(transition());
        SceneManager.LoadScene("level1");


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
        SceneManager.LoadScene("Level2_cleaned");
        Time.timeScale = 1;
    }
     IEnumerator transition()
    {
        SceneManager.LoadScene("transition");
        yield return new WaitForSeconds(7);
    }
}
