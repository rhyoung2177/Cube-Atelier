using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BGM;

    // Start is called before the first frame update

    void Start()
    {
        PlayerPrefs.SetInt("bgmonoff", 1);
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BGM;
        audioSource.volume = 1.0f;
        audioSource.loop = true;
        audioSource.mute = false; 
        audioSource.Play();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("bgmonoff", 1) == 1)
            audioSource.volume = 1.0f;
        else
            audioSource.volume = 0.0f;
    }   
}
