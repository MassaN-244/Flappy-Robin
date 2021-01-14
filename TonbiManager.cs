using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonbiManager : MonoBehaviour
{
    GameObject robin;
    // Start is called before the first frame update
    void Start()
    {
        robin = GameObject.Find("Robin");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        
        Vector3 myPos = transform.position;
        Vector3 robinPos = robin.transform.position;
        float EagleMoveSpeed = 0.003f;

        transform.position = Vector3.MoveTowards(transform.position, robinPos, EagleMoveSpeed);

        if (robinPos.x > myPos.x && scale.x > 0)  
        {
            scale.x = scale.x * -1;
        }
        transform.localScale = scale;
    }
}
