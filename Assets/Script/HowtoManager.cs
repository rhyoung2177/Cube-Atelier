using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowtoManager : MonoBehaviour
{
    int LogID;
    public GameObject[] im;

    void Start()
    {
        for (int i = 1; i < 6; i++)
           im[i].SetActive(false);
        LogID = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtLeftDown()
    {
        im[LogID].SetActive(false);
        if (LogID != 0)
            LogID--;
        im[LogID].SetActive(true);
    }

    public void BtRightDown()
    {
        im[LogID].SetActive(false);
        if (LogID != 5)
            LogID++;
        im[LogID].SetActive(true);
    }
}
