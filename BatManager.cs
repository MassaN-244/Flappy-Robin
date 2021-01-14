using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    GameObject robin;

    void Start()
    {
        robin = GameObject.Find("Robin");
    }

    void Update()
    {
        Vector3 scale = transform.localScale;

        Vector3 myPos = transform.position;
        Vector3 robinPos = robin.transform.position;
        float BatMoveSpeed = 0.005f;

        transform.position = Vector3.MoveTowards(transform.position, robinPos, BatMoveSpeed);

        if (robinPos.x > myPos.x && scale.x > 0)
        {
            scale.x = scale.x * -1;
        }
        transform.localScale = scale;
    }
}
