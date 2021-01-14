using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateManager : MonoBehaviour
{
    public GameObject beanPrefab;
    public GameObject eaglePrefab;
    public GameObject tonbiPrefab;
    public GameObject goldeneggPrefab;
    public GameObject batPrefab;

    public GameObject robin;

    float generatespeed_Easy = 2.0f;
    float generatespeed_Normal = 1.8f;     //Normalインスタンス生成速度
    float generatespeed_Hard = 1.5f;

    List<GameObject> list_Instance = new List<GameObject>();
    
    void Start()
    {
        //プレハブから生成
        Generate();
    }

    void Update()
    {
        
    }

    void Generate()
    {
        Vector3 robinPos = robin.transform.position;
        float randomHeight = Random.Range(-3.7f, 3.7f);
        float probability = Random.Range(1.0f, 100.0f);     //確率を表すのに必要な変数
        
        Vector3 generatepos = new Vector3(robinPos.x + 5.0f, randomHeight,0);

        //難易度ごとの確率設定

        //Easy
        if (SceneManager.GetActiveScene().name == "EasyScene")
        {
            if (probability <= 30)  //イーグル生成
            {
                GameObject Instance = Instantiate(eaglePrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 30 && probability <= 90)     //ビーン生成
            {
                GameObject Instance = Instantiate(beanPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 90) 　   //卵生成
            {
                GameObject Instance = Instantiate(goldeneggPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }

            for (int i = 0; i < list_Instance.Count; i++)
            {
                Destroy(list_Instance[i], 6.0f);
            }

            Invoke("Generate", generatespeed_Easy);     //各generatespeedでこの関数自体を呼び出す
        }


        //Normal
        else if (SceneManager.GetActiveScene().name == "NormalScene")
        {
            if (probability <= 50)  //イーグル生成
            {
                GameObject Instance = Instantiate(eaglePrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 50 && probability <= 90)     //ビーン生成
            {
                GameObject Instance = Instantiate(beanPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 90 && probability <= 95)     //トンビ生成
            {
                GameObject Instance = Instantiate(tonbiPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 95)     //卵生成
            {
                GameObject Instance = Instantiate(goldeneggPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }

            for (int i = 0; i < list_Instance.Count; i++)
            {
                Destroy(list_Instance[i], 6.0f);
            }

            Invoke("Generate", generatespeed_Normal);
        }


        //Hard
        else if (SceneManager.GetActiveScene().name == "HardScene")
        {
            if (probability <= 30)  //イーグル生成
            {
                GameObject Instance = Instantiate(eaglePrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 30 && probability <= 60)     //トンビ生成
            {
                GameObject Instance = Instantiate(tonbiPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 60 && probability <= 65)     //コウモリ生成
            {
                GameObject Instance = Instantiate(batPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 65 && probability <= 95)     //ビーン生成
            {
                GameObject Instance = Instantiate(beanPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }
            else if (probability > 95)  //卵生成
            {
                GameObject Instance = Instantiate(goldeneggPrefab, generatepos, Quaternion.identity);
                list_Instance.Add(Instance);
            }

            for (int i = 0; i < list_Instance.Count; i++)
            {
                Destroy(list_Instance[i], 6.0f);
            }

            Invoke("Generate", generatespeed_Hard);
        }
    }       
}
