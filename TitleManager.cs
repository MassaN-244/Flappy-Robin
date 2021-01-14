using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject recordCanvas;

    public GameObject bestScore_Hard;
    public GameObject bestScore_Normal;
    public GameObject bestScore_Easy;

    public GameObject playTime_Hard;
    public GameObject playTime_Normal;
    public GameObject playTime_Easy;

    public GameObject bestLength_Easy;
    public GameObject bestLength_Normal;
    public GameObject bestLength_Hard;

    public static int time_Hard = 0;
    public static int time_Normal = 0;
    public static int time_Easy = 0;



    private void Start()
    {
        time_Easy = PlayerPrefs.GetInt("EASYTIME");
        time_Normal = PlayerPrefs.GetInt("NORMALTIME");
        time_Hard = PlayerPrefs.GetInt("HARDTIME");

        bestScore_Hard.GetComponent<Text>().text = "BestScore : " + PlayerPrefs.GetInt("HARDBESTSCORE");
        bestScore_Normal.GetComponent<Text>().text = "BestScore : " + PlayerPrefs.GetInt("NORMALBESTSCORE");
        bestScore_Easy.GetComponent<Text>().text = "BestScore : " + PlayerPrefs.GetInt("EASYBESTSCORE");

        playTime_Easy.GetComponent<Text>().text = "プレイ回数 : " + PlayerPrefs.GetInt("EASYTIME");
        playTime_Normal.GetComponent<Text>().text = "プレイ回数 : " + PlayerPrefs.GetInt("NORMALTIME");
        playTime_Hard.GetComponent<Text>().text = "プレイ回数 : " + PlayerPrefs.GetInt("HARDTIME");

        bestLength_Easy.GetComponent<Text>().text = "BestLength : " + PlayerPrefs.GetInt("EASYBESTLENGTH") + "m";
        bestLength_Normal.GetComponent<Text>().text = "BestLength : " + PlayerPrefs.GetInt("NORMALBESTLENGTH") + "m";
        bestLength_Hard.GetComponent<Text>().text = "BestLength : " + PlayerPrefs.GetInt("HARDBESTLENGTH") + "m";
    }
    public void PushButton1()       //画面遷移処理
    {
        SceneManager.LoadScene("EasyScene");

        time_Easy++;
        PlayerPrefs.SetInt("EASYTIME", time_Easy);
        PlayerPrefs.Save();
    }

    public void PushButton2()       //画面遷移処理
    {
        SceneManager.LoadScene("NormalScene");

        time_Normal++;
        PlayerPrefs.SetInt("NORMALTIME", time_Normal);
        PlayerPrefs.Save();
    }

    public void PushButton3()       //画面遷移処理
    {
        SceneManager.LoadScene("HardScene");

        time_Hard++;
        PlayerPrefs.SetInt("HARDTIME", time_Hard);
        PlayerPrefs.Save();
    }

    public void PushMenuButton()
    {
        menuCanvas.SetActive(true);
    }

    public void PushReturn1()
    {
        menuCanvas.SetActive(false);
    }

    public void PushRecord()
    {
        menuCanvas.SetActive(false);
        recordCanvas.SetActive(true);
    }

    public void PushReturn2()
    {
        recordCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void PushHowToPlay()
    {
        SceneManager.LoadScene("ExplainScene");
    }

    public void PushReturn3()
    {
        menuCanvas.SetActive(true);
    }
}
