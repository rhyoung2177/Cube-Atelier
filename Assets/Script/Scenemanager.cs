using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public GameObject [] BG, SC;
    public Text resultText;
    string[] TextColor = { "<color=#ffa9d0>" , "<color=#8eb6e8>" , "<color=#efae77>", "<color=#9479d1>" };

    void Start()
    {
        int num, num0, num1 = 0;
        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            for (int i = 0; i < 4; i++)
                BG[i].SetActive(false);
        
            for (int i = 0; i < 13; i++)
                SC[i].SetActive(false);
        
            int t = (PlayerPrefs.GetInt("Time", 0) / 60);
            if (t > 2) t = 2;
            
            num = int.Parse(PlayerPrefs.GetString("StageNumber"));
            num0 = (num / 10) - 1;
            num1 = num % 10;

            BG[num0].SetActive(true);
            SC[((num0+1)*3) - t].SetActive(true);

            resultText.text = TextColor[num0] + "Stage " + (num0 + 1).ToString() + "-" + num1.ToString()
                + "\n Time " + PlayerPrefs.GetInt("Time", 0) / 60 + ":" + PlayerPrefs.GetInt("Time", 0) % 60 + "</color>";
        }
    }

    void Update()
    {
    }
    
    public void StageBT_Down()
    {
        string ST_String = EventSystem.current.currentSelectedGameObject.name.Substring(3, 1) + "StageScene";
        if (SceneManager.GetActiveScene().name.Substring(1, 1) == "_")
            ST_String = SceneManager.GetActiveScene().name.Substring(0, 1) + "StageScene";
        SceneManager.LoadScene(ST_String);
    }
    
    public void GameBT_Down()
    {
        string ST_String = SceneManager.GetActiveScene().name.Substring(0, 1) + "_" + EventSystem.current.currentSelectedGameObject.name.Substring(3, 1);
        if (SceneManager.GetActiveScene().name.Substring(1, 1) == "_")
            ST_String = SceneManager.GetActiveScene().name;
        if (EventSystem.current.currentSelectedGameObject.name.Substring(3, 1) != "R")
            PlayerPrefs.SetString("StageNumber", SceneManager.GetActiveScene().name.Substring(0, 1) + EventSystem.current.currentSelectedGameObject.name.Substring(3, 1));
        PlayerPrefs.SetInt("RestartQuiz", 0);
        SceneManager.LoadScene(ST_String);
    }

    public void BtStageDown()
    {
        SceneManager.LoadScene("0StageScene");
    }

    public void BtHowtoDown()
    {
        SceneManager.LoadScene("HowtoScene");
    }

    public void BtSettingDown()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void BtMenuDown()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void BtRestartDown()
    {
        PlayerPrefs.SetInt("RestartQuiz", 1);
    }
}
