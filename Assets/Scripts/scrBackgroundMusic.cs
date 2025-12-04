using UnityEngine;

public class scrBackgroundMusic : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip backgroundMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
