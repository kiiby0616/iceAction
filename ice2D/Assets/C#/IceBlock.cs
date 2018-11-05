using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour {

    public GameObject parent;
    public Enemy ene;
    private Collider2D col2D;

    private GameObject ScoreUI;
    ScoreText ST;

    // Use this for initialization
    void Start() {
        //親取得
        parent = gameObject.transform.parent.gameObject;
        ene = parent.GetComponent<Enemy>();
        col2D = GetComponent<Collider2D>();

        ScoreUI = GameObject.FindGameObjectWithTag("Score");
        ST = ScoreUI.GetComponent<ScoreText>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("x"))
            {
                ene.Shoot();
                this.tag = "iceBlock_Attack";
                col2D.isTrigger = true;
                ST.ScorePlus(50);
            }
            
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
