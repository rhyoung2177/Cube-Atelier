using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class QuizManager : MonoBehaviour
{
    GameObject Window, RestartBT;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Quiz1", 0);
        PlayerPrefs.SetInt("Quiz2", 0);
        PlayerPrefs.SetInt("Quiz3", 0);
        this.Window = GameObject.Find("QuizWindow");
        this.RestartBT = GameObject.Find("Bt_Restart");
        PlayerPrefs.SetInt("QuizWindow", 0);
        if (SceneManager.GetActiveScene().name.Substring(0, 1) != "0")
            this.RestartBT.SetActive(false);
        if (PlayerPrefs.GetInt("RestartQuiz", 0) == 1)
        {
            this.Window.SetActive(false);
            this.RestartBT.SetActive(true);
        }
    }

    public void QuizRight1()
    {
        PlayerPrefs.SetInt("Quiz1", 1);
        PlayerPrefs.Save();
    }

    public void QuizWrong1()
    {
        PlayerPrefs.SetInt("Quiz1", 0);
        PlayerPrefs.Save();
    }

    public void QuizRight2()
    {
        PlayerPrefs.SetInt("Quiz2", 1);
        PlayerPrefs.Save();
    }

    public void QuizWrong2()
    {
        PlayerPrefs.SetInt("Quiz2", 0);
        PlayerPrefs.Save();
    }

    public void QuizRight3()
    {
        PlayerPrefs.SetInt("Quiz3", 1);
        PlayerPrefs.Save();
    }

    public void QuizWrong3()
    {
        PlayerPrefs.SetInt("Quiz3", 0);
        PlayerPrefs.Save();
    }

    public void QuizResult()
    {
        if (PlayerPrefs.GetInt("Quiz1", 0) == 1 && PlayerPrefs.GetInt("Quiz2", 0) == 1 && PlayerPrefs.GetInt("Quiz3", 0) == 1)
        {
            PlayerPrefs.SetInt("QuizWindow", 1);
            this.Window.SetActive(false);
            this.RestartBT.SetActive(true);
        }
    }
}
