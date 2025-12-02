using UnityEngine;

public class scrMenuMusicPlayer : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip backgroundMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().loop = true;
        sound.PlayOneShot(backgroundMusic);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
