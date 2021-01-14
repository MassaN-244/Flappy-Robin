using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject robin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 robinpos = robin.transform.position;
        Vector3 backpos = transform.position;

        Vector3 distance = robinpos - backpos;

        if (distance.x >= 6)
        {
            transform.position = new Vector3(robinpos.x, 0, 0);
        }
    }
}
