using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] LayerMask blockLayer;
    [SerializeField] GameObject deathEffect;
    
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rigidbody2D;
    float speed;

    //float jumPower = 400;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        direction = DIRECTION_TYPE.RIGHT;

    }
    private void Update()
    {
        if (!IsGround() || IsWall()) 
        {
            ChangeDirection();
        }
    }
    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 2.5f;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -2.5f;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    bool IsGround()
    {
        Vector3 startVec = transform.position + transform.right * 0.3f * transform.localScale.x;
        Vector3 endVec = transform.position - transform.up * 0.5f;

        Debug.DrawLine(startVec, endVec);

        return Physics2D.Linecast(startVec,endVec,blockLayer);
    }
    bool IsWall()
    {
        Vector3 startVec2 = transform.position + transform.right * 0.3f * transform.localScale.x;
        Vector3 endVec2 = transform.position + transform.right * 0.5f * transform.localScale.x;

        Debug.DrawLine(startVec2, endVec2);

        return Physics2D.Linecast(startVec2, endVec2, blockLayer);
    }

    void ChangeDirection()
    {
        if (direction == DIRECTION_TYPE.RIGHT)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
        else if (direction == DIRECTION_TYPE.LEFT)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
    }

    public void DestroyEnemy()
    {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

}
