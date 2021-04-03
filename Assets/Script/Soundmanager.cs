using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioClip SFX_BT;
    public AudioClip SFX_CubeBT;
    public AudioSource audioSource;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }   

    public void PlaySFX_BT()
    {
        if (PlayerPrefs.GetInt("SFX_Volume", 1) == 1) AudioSource.PlayClipAtPoint(SFX_BT, new Vector3(0,0,0));
    }

    public void PlaySFX_CubeBT()
    {
        if (PlayerPrefs.GetInt("SFX_Volume", 1) == 1) AudioSource.PlayClipAtPoint(SFX_CubeBT, new Vector3(0, 0, 0));
    }
    
}
