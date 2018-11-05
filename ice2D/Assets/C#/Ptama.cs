using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptama : MonoBehaviour {
    private GameObject player;
    public float speed = 30;
    
	// Use this for initialization
	void Start () {
        //プレイヤオブジェクト取得
        player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rd2D = GetComponent<Rigidbody2D>();
        //プレイヤーの前方へ球を飛ばす
        rd2D.velocity = new Vector2(speed * player.transform.localScale.x, rd2D.velocity.y);
        //向きを合わせる
        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x;
        transform.localScale = temp;
          
	}
	
	// Update is called once per frame
	void Update () {
        //画面外に出たら消える
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
