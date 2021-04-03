using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Datamanager : MonoBehaviour
{
    public GameObject [] BT1, IM1, SC;

    // Start is called before the first frame update
    void Start()
    {
        DataInit();
        DataUpdate();
    } 

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBGM()
    {
        PlayerPrefs.SetInt("bgmonoff", 1);
    }

    public void StopBGM()
    {
        PlayerPrefs.SetInt("bgmonoff", 0);
    }

    public void PlaySFX()
    {
        PlayerPrefs.SetInt("SFX_Volume", 1);
    }
    public void StopSFX()
    {
        PlayerPrefs.SetInt("SFX_Volume", 0);
    }

    void DataInit()
    {
        BT1[0].SetActive(false);
        for (int i = 0; i < 7; i++)
        {
            BT1[i].SetActive(false);
            IM1[i].SetActive(false);
        }
        for (int i = 0; i < 19; i++)
            SC[i].SetActive(false);
    }
    void DataUpdate()
    {
        string CLMessage = "Clear";
        string SCMessage = "Score";
        string StMessage = SceneManager.GetActiveScene().name.Substring(0, 1);
        for (int i = 1; i < 7; i++)
        {
            string temp = CLMessage + StMessage + "_" + i.ToString();
            if (PlayerPrefs.GetInt(temp, 0) == 1)
            {
                BT1[i].SetActive(true);
                IM1[i].SetActive(true);
                temp = SCMessage + StMessage + "_" + i.ToString();
                SC[(i - 1) * 3 + PlayerPrefs.GetInt(temp, 0)].SetActive(true);
            }
        }

        int num = 1;
        while (num < 7)
        {
            string temp = CLMessage + StMessage + "_" + num.ToString();
            if (PlayerPrefs.GetInt(temp, 0) != 1) break;
            num++;
            if (num > 6)
                BT1[0].SetActive(true);
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
} 