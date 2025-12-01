using UnityEngine;
using UnityEngine.SceneManagement;

public class scrMainMenu : MonoBehaviour
{
    public GameObject controlMenu;
    public GameObject infoMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    public void ControlBtn()
    {
        controlMenu.SetActive(true);
        infoMenu.SetActive(false);
    }
    public void InfoBtn()
    {
        controlMenu.SetActive(false);
        infoMenu.SetActive(true);
    }
}
