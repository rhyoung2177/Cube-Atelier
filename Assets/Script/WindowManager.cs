using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    GameObject Window;

    // Start is called before the first frame update
    void Start()
    {
        this.Window = GameObject.Find("PauseWindow");
        this.Window.SetActive(false);
        PlayerPrefs.SetInt("PauseWindow", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WindowView() {
        PlayerPrefs.SetInt("PauseWindow", 1);
        this.Window.SetActive(true);
    }

    public void WindowUnView()
    {
        PlayerPrefs.SetInt("PauseWindow", 0);
        this.Window.SetActive(false);
    }
}
