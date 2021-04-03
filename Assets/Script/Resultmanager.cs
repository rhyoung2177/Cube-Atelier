using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resultmanager : MonoBehaviour
{
    int i = 0;
    int [] AnswerBlock = {0, 12, 11, 21, 18, 19, 10, 19, 19, 20, 29, 10, 17, 14, 12, 16, 13, 23, 14, 17, 52, 14, 16, 18, 28 };

    void Start()
    {
    }
    
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Cube")
            i++;

        int StageNumber = (int.Parse(SceneManager.GetActiveScene().name.Substring(0, 1)) - 1) * 6 + +int.Parse(SceneManager.GetActiveScene().name.Substring(2, 1));
        int AnswerNumber = AnswerBlock[StageNumber];
        string ST_String1 = SceneManager.GetActiveScene().name.Substring(0, 1);
        string ST_String2 = SceneManager.GetActiveScene().name.Substring(2, 1);
        string CL_String = "Clear" + ST_String1 + "_" + ST_String2;
        string SC_String = "Score" + ST_String1 + "_" + ST_String2;

        switch (StageNumber)
        {
            case 1:case 2:case 3:case 4:case 5: case 6:case 7:case 8:case 9:case 10:case 11:case 12:
            case 13:case 14:case 15:case 16:case 17:case 18:case 19:case 20:case 21:case 22:case 23:
            case 24:
                if (i == AnswerNumber)
                {
                    SceneManager.LoadScene("ResultScene");
                    PlayerPrefs.SetInt(CL_String, 1);
                    if (PlayerPrefs.GetInt("Time", 0) >= 120)
                        PlayerPrefs.SetInt(SC_String, 1);
                    else if (PlayerPrefs.GetInt("Time", 0) >= 60)
                        PlayerPrefs.SetInt(SC_String, 2);
                    else
                        PlayerPrefs.SetInt(SC_String, 3);
                }
                break;
        }
    }
}