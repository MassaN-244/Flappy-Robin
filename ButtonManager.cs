using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] canvas = new GameObject[4];
    public GameObject[] button = new GameObject[4];

    public void PushEscape()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Push1()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                canvas[i].SetActive(true);
                button[i].GetComponent<Image>().color = new Color(255f/255f, 138f/255f, 0.0f, 1.0f);
            }
            else
            {
                canvas[i].SetActive(false);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 137f / 255f);
            }
        }
    }

    public void Push2()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 1)
            {
                canvas[i].SetActive(true);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 1.0f);
            }
            else
            {
                canvas[i].SetActive(false);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 137f / 255f);
            }
        }
    }

    public void Push3()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 2)
            {
                canvas[i].SetActive(true);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 1.0f);
            }
            else
            {
                canvas[i].SetActive(false);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 137f / 255f);
            }
        }
    }

    public void Push4()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i == 3)
            {
                canvas[i].SetActive(true);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 1.0f);
            }
            else
            {
                canvas[i].SetActive(false);
                button[i].GetComponent<Image>().color = new Color(255f / 255f, 138f / 255f, 0.0f, 137f / 255f);
            }
        }
    }
}
