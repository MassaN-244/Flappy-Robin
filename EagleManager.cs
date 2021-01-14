using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleManager : MonoBehaviour
{
    bool judgeRotate;
    float rotateEdge = 1f;

    // Start is called before the first frame update
    void Start()
    {
        PositiveRotate();
    }

    // Update is called once per frame
    void Update()
    {
        if (judgeRotate == true)
        {
            transform.Rotate(new Vector3(0, 0, -1f));
        }
        else if (judgeRotate == false) 
        {
            transform.Rotate(new Vector3(0, 0, 1f));
        }
    }

    void PositiveRotate()
    {
        bool judgeRotate = true;
        Invoke("NegativeRotate", 0.1f);
    }

    void NegativeRotate()
    {
        bool judgeRotate = false;
        Invoke("PositiveRotate", 0.1f);
    }

    /*void WaveObject()
    {
        if (this.transform.localEulerAngles.z >= 10 && rotateEdge > 0)
        {
            rotateEdge = -0.1f;
            transform.Rotate(new Vector3(0, 0, rotateEdge));
        }
        else if (this.transform.localEulerAngles.z <= -10 && rotateEdge < 0) 
        {
            rotateEdge = 0.1f;
            transform.Rotate(new Vector3(0, 0, rotateEdge));
        }
        
    }*/
}
