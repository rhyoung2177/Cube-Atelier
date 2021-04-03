using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;
    private int t = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "00:00";
        StartCoroutine("Timer");
    }

    void Update()
    {
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        t++;
        PlayerPrefs.SetInt("Time", t);
        UpdateString();
        StartCoroutine("Timer");
    }

    void UpdateString()
    {
        string minutes1 = (((int)t / 60) / 10).ToString();
        string minutes2 = (((int)t / 60) % 10).ToString();
        string seconds1 = (((int)t % 60) / 10).ToString("f0");
        string seconds2 = (((int)t % 60) % 10).ToString("f0");
        timerText.text = minutes1 + minutes2 + ":" + seconds1 + seconds2;
    }
}
