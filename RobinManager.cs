using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class RobinManager : MonoBehaviour
{
    Rigidbody2D rb;     
    float speed = 0.005f;
    
    public GameObject gameOverCanvas;

    public GameObject scoreText;    
    int score = 0;
    public GameObject highScoreText;
    public GameObject lengthText;

    static int highScore_Easy = 0;
    static int highScore_Normal = 0;
    static int highScore_Hard = 0;


    public GameObject bgmManager;

    public AudioClip item;
    public AudioClip rareitem;
    public AudioClip gameover;
    public AudioClip newbest;

    AudioSource audioSource;
    AudioSource bgmSource;

    static int length_Easy = 0;
    static int length_Normal = 0;
    static int length_Hard = 0;
    float length = 0;
    bool isCount = true;

    float robinVelocity = 10;

    bool oneshot = false;



    void Start()
    {
        highScore_Easy = PlayerPrefs.GetInt("EASYBESTSCORE");
        highScore_Normal = PlayerPrefs.GetInt("NORMALBESTSCORE");
        highScore_Hard = PlayerPrefs.GetInt("HARDBESTSCORE");

        length_Easy = PlayerPrefs.GetInt("EASYBESTLENGTH");
        length_Normal = PlayerPrefs.GetInt("NORMALBESTLENGTH");
        length_Hard = PlayerPrefs.GetInt("HARDBESTLENGTH");

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        bgmSource = bgmManager.GetComponent<AudioSource>(); //BgmManagerのコンポーネント取得

        //highScoreの初期表示
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            highScoreText.GetComponent<Text>().text = "BestScore:" + PlayerPrefs.GetInt("EASYBESTSCORE");           
        }
        else if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            highScoreText.GetComponent<Text>().text = "BestScore:" + PlayerPrefs.GetInt("NORMALBESTSCORE");
        }
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            highScoreText.GetComponent<Text>().text = "BestScore:" + PlayerPrefs.GetInt("HARDBESTSCORE");
        }
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);

        if (gameOverCanvas.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(0.0f, 6.0f);
            }
        }

        if (isCount == true)
        {
            length += robinVelocity * Time.deltaTime;
            lengthText.GetComponent<Text>().text = (int)length + " m";
        }

        if (!oneshot)
        {
            oneshot = true;
            NewBest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //衝突処理
    {
        if (collision.gameObject.tag == "Bean")
        {
            Destroy(collision.gameObject);
            GetScore();

            audioSource.PlayOneShot(item);
        }
        else if (collision.gameObject.tag == "Eagle")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "Tonbi")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "Bat")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "GoldenEgg")
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.GetComponent<Text>().text = "Score" + score.ToString();
            audioSource.PlayOneShot(rareitem);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)   //OutZoneとの接触時の処理 
    {
        GameOver();
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);   //GameOverキャンバスの呼び出し

        audioSource.PlayOneShot(gameover);
        bgmSource.Stop();
        isCount = false;

        JudgeAndSetHighScore();
    }

    void GetScore()
    {
        score++;

        scoreText.GetComponent<Text>().text = "Score " + score.ToString(); 
    }

    void NewBest()
    {
        if ((int)length % 100 == 0 && (int)length != 0) 
        {
            audioSource.PlayOneShot(newbest);
        }
    }

    void JudgeAndSetHighScore()     //highscoreを判定・設定・セーブ
    {
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            if ((int)length > length_Easy)
            {
                length_Easy = (int)length;
                PlayerPrefs.SetInt("EASYBESTLENGTH", length_Easy);
            }
            if (score > highScore_Easy)
            {
                highScore_Easy = score;
                PlayerPrefs.SetInt("EASYBESTSCORE", highScore_Easy);
            }
            PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            if ((int)length > length_Normal)
            {
                length_Normal = (int)length;
                PlayerPrefs.SetInt("NORMALBESTLENGTH", length_Normal);
            }
            if (score > highScore_Normal)
            {
                highScore_Normal = score;
                PlayerPrefs.SetInt("NORMALBESTSCORE", highScore_Normal);                 
            }
            PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            if ((int)length > length_Hard)
            {
                length_Hard = (int)length;
                PlayerPrefs.SetInt("HARDBESTLENGTH", length_Hard);
            }
            if (score > highScore_Hard)
            {
                highScore_Hard = score;
                PlayerPrefs.SetInt("HARDBESTSCORE", highScore_Hard);                
            }
            PlayerPrefs.Save();
        }
    }

    public void Retry()
    {
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            SceneManager.LoadScene("EasyScene");
            TitleManager.time_Easy++;
            PlayerPrefs.SetInt("EASYTIME", TitleManager.time_Easy);
            PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            SceneManager.LoadScene("NormalScene");
            TitleManager.time_Normal++;
            PlayerPrefs.SetInt("NORMALTIME", TitleManager.time_Normal);
            PlayerPrefs.Save();
        }
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            SceneManager.LoadScene("HardScene");
            TitleManager.time_Hard++;
            PlayerPrefs.SetInt("HARDTIME", TitleManager.time_Hard);
            PlayerPrefs.Save();
        }

        //SceneManager.LoadScene("SceneManager.GetActiveScene().name")だけでもいいかも
        
    }
    public void Title()
    {
        SceneManager.LoadScene("TitleScene");
    }


}
