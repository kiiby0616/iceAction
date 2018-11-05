using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercon : MonoBehaviour
{
    public float speed = 150f;

    public float jumpForce = 700f;
    public LayerMask grondLayer;
    public LayerMask iceblock;
    private bool isground;
    private bool isiceblock;

    public GameObject yukitama;

    Rigidbody2D rd2D;

    GameObject[] yukitamaC;

    GameObject iceBlock;
    GameObject iceBlock_enemy;

    private Animator animT;
    private GameObject hpber;
    HpBer hp;
    private float hppoint = 100f;
    private GameObject ScoreUI;
    ScoreText ST;

    private bool hitflag = false;
    private float hitAtime = 0;
    private SpriteRenderer renderer;
    private Collider2D col2D;

    
    // Use this for initialization
    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        hpber = GameObject.FindGameObjectWithTag("Hpber");
        hp = hpber.GetComponent<HpBer>();
        ScoreUI = GameObject.FindGameObjectWithTag("Score");
        ST = ScoreUI.GetComponent<ScoreText>();
        animT = GetComponent<Animator>();
        col2D = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        TamaAttack();
        Clamp();
        HpControll();
        //ダメージフラグがture時に点滅
        if (hitflag)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
           renderer.color =new Color(1f,1f,1f,level);
        }
    }

    void FixedUpdate()
    {
        Walk();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy"　&& !hitflag)
        {
            hp.Damage(10);
            hppoint -= 10;
            OnHitEffect();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "iceBlock")
        {
            if (Input.GetKeyDown("x"))
            {
                if (isiceblock)
                {
                    isground = false;
                    rd2D.AddForce(Vector2.up * jumpForce * 150);
                }
            }
        }
        if (collision.gameObject.tag == "iceBlock_Attack")
        {
            if (Input.GetKeyDown("x"))
            {
                if (isiceblock)
                {
                    isground = false;
                    rd2D.AddForce(Vector2.up * jumpForce * 150);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "point")
        {
            Destroy(collision.gameObject);
            ST.ScorePlus(10);
        }
    }

    void Walk()
    {
        //左キー：-1、右キー：1
        float x = Input.GetAxisRaw("Horizontal");
        //右か左を入力したら
        if (x != 0)
        {
            rd2D.velocity = new Vector2(x * speed, rd2D.velocity.y);
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;
        }
        if (x == 0)
        {
            rd2D.velocity = new Vector2(0, rd2D.velocity.y);
        }
    }
    
    void Jump()
    {
        Vector3 PlayerPos = transform.position;
        //足元に地面あるか判定
        isground = Physics2D.Linecast(
            new Vector3(PlayerPos.x - 10f, PlayerPos.y - 0.05f, PlayerPos.z),
            new Vector3(PlayerPos.x + 10f, PlayerPos.y - 0.05f, PlayerPos.z),
            grondLayer);
        isiceblock = Physics2D.Linecast(
            new Vector3(PlayerPos.x - 10f, PlayerPos.y - 0.05f, PlayerPos.z),
            new Vector3(PlayerPos.x + 10f, PlayerPos.y - 0.05f, PlayerPos.z),
            iceblock);
        //スペースキーを押す
        if (Input.GetKeyDown("space"))
        {

            //着地していた時
            if (isground)
            {
                isground = false;
                rd2D.AddForce(Vector2.up * jumpForce * 100);
            }
            if (isiceblock)
            {
                isground = false;
                rd2D.AddForce(Vector2.up * jumpForce * 100);
            }
        }
        
    }
    void TamaAttack()
    {
        yukitamaC = GameObject.FindGameObjectsWithTag("Ptama");
        //Zキーを押したら球発射
        if (Input.GetKeyDown("z") && yukitamaC.Length < 3) 
        {
            GameObject yukitama= Instantiate(this.yukitama, transform.position + new Vector3(0f, 18f, 0f), transform.rotation);
            
        }
        
    }

   void Clamp()
    {
        //移動制限
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        transform.position = pos;
    }

   void OnHitEffect()
    {
        hitflag = true;
        //プレイヤーの位置を後ろに吹き飛ばす
        float s = 2000f * Time.deltaTime;
        transform.Translate(Vector3.up * s*0.5f);

        if (transform.localScale.x > 0)
        {
            transform.Translate(Vector3.left * s);
        }
        else
        {

            transform.Translate(Vector3.right * s);
        }

        StartCoroutine("WaitForIt");
    }

    private void HpControll() {
        //HPが0かつ地面に当たった時、動けなくなり敵をすり抜ける
        if(hppoint <= 0 && isground)
        {
            animT.SetTrigger("miss");
            speed = 0;
            jumpForce = 0;
            Scene Lscene = SceneManager.GetActiveScene();
            rd2D.isKinematic = true;
            col2D.isTrigger = true;

            if (Input.GetKeyDown("z"))
            {
                SceneManager.LoadScene(Lscene.name);
            }
        }
    }

    IEnumerator WaitForIt()
    {
        //１秒間処理を止める
        yield return new WaitForSeconds(1);

        hitflag = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}