using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] LayerMask blockLayer;
    [SerializeField] GameManager gameManager;
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }
    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rigidbody2D;
    float speed;

    Animator animator;

    //SE
    [SerializeField] AudioClip getItemSE;
    [SerializeField] AudioClip jumpSE;
    [SerializeField] AudioClip stampSE;
    AudioSource audioSource;

    float jumPower = 600;
    bool isDead = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isDead)
        {
            return;
        }

        float x = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(x));

        if (x == 0)
        {
            direction = DIRECTION_TYPE.STOP;
        }
        else if (x > 0)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
        else if (x < 0)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
        //spaceジャンプ
        if (IsGround() && Input.GetKeyDown("space")) 
        { 
            if(Input.GetKeyDown("space"))
            {
                Jump(); 
            }
            else
            {
                animator.SetBool("isjumping", false);
            }              
            //Invoke(animator.SetBool("isjumping", false), 1.5f);
                
        }
    }
    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 4;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -4;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumPower);
            //Vector2.upは、上方向の単位ベクトル→jumpPowerをかけて大きさの変更
        Debug.Log("Jump");
        audioSource.PlayOneShot(jumpSE);
        //animator.Play("PlayerJump Animation");

        animator.SetBool("isjumping", true);
    }

    bool IsGround()
    {
        //始点と終点を作成
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;     //左側の始点
        Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;    //右側の始点
        Vector3 endPoint = transform.position - Vector3.up * 0.2f;

        Debug.DrawLine(leftStartPoint, endPoint);
        Debug.DrawLine(rightStartPoint, endPoint);

        return Physics2D.Linecast(leftStartPoint, endPoint, blockLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("ゲームオーバー");
            PlayerDeath();
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("クリア");
            gameManager.GameClear();
        }
        else if (collision.gameObject.tag == "Item")
        {
            audioSource.PlayOneShot(getItemSE);
            collision.gameObject.GetComponent<ItemManager>().GetItem();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();

            if (this.transform.position.y + 0.2f > enemy.transform.position.y) 
            {
                    //上から敵に衝突
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                
                jumPower = 400;
                Jump();
                audioSource.PlayOneShot(stampSE);
                enemy.DestroyEnemy();
                jumPower = 600;

            }
            else  //横から敵に衝突
            {
                PlayerDeath();
            }
        }
    }

    void PlayerDeath()
    {
        isDead = true;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(Vector2.up * jumPower);
        animator.Play("PlayerDeathAnimation");
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        Destroy(boxCollider2D);
        gameManager.GameOver();
    }
}
