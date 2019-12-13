using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Michael worked on this one
public class PlayMusic : MonoBehaviour
{
    public AudioClip IntroMusic;
    public AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = IntroMusic;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
