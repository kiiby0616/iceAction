using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Rigidbody2D rd2D;
    public float speed;
    private float time;
    public float kyori;
    private float Tswichi = 1;
    private float Tswichi2 = -1;
    private bool icebool = false;

    GameObject player;
    Vector2 playerPos,EnemyPos, EneToPlaPos;

    private GameObject ScoreUI;
    ScoreText ST;

    Animator anim;
    Collider2D col2D;
	// Use this for initialization
	void Start () {
        rd2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        col2D = GetComponent<Collider2D>();
        ScoreUI = GameObject.FindGameObjectWithTag("Score");
        ST = ScoreUI.GetComponent<ScoreText>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= kyori)
        {
            time = 0;
            Tswichi *= Tswichi2;
        }
        playerPos = player.transform.position;
        EnemyPos = gameObject.transform.position;
        EneToPlaPos = playerPos - new Vector2(EnemyPos.x,EnemyPos.y-17f);

	}

    private void FixedUpdate()
    {
        if (icebool == false)
        {
            Walk(Tswichi, speed);
        }
    }

   void Walk(float Tswich,float speed)
    {
        rd2D.velocity = new Vector2(Tswich * -speed , rd2D.velocity.y);
        Vector2 temp = transform.localScale;
        temp.x = -Tswich;
        transform.localScale = temp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Ptama") 
        {
            icebool = true;
            rd2D.velocity = Vector2.zero;
            speed = 0;
        }
        if (collision .gameObject .tag == "iceBlock_Attack")
        {
            if (!gameObject.HasChild())
            {
                rd2D.velocity = Vector2.zero;
                speed = 0;
                col2D.isTrigger = true;
                anim.SetTrigger("burn");
                Invoke("Des", 1f);
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnCenser")
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        speed = 400;
        if (EneToPlaPos.x > 0 && EneToPlaPos.y >=0 && EneToPlaPos.y <= 30)
        {
            rd2D.velocity = new Vector2(-1 * speed, rd2D.velocity.y);
        }
        if (EneToPlaPos.x < 0 && EneToPlaPos.y >= 0 && EneToPlaPos.y <= 30) 
        {
            rd2D.velocity = new Vector2(speed, rd2D.velocity.y);
        }
        if(EneToPlaPos.y > 30)
        {
            rd2D.velocity = new Vector2(rd2D.velocity.x, speed *-1);
        }
       
    }
    private void Des()
    {
        Destroy(gameObject);
    }
}
