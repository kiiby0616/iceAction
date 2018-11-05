using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_controll : MonoBehaviour {
    private GameObject hpber;
    HpBer hp;


	// Use this for initialization
	void Start () {
        hpber = GameObject.FindGameObjectWithTag("Hpber");
        hp = hpber.GetComponent<HpBer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            hp.Damage(10);
        }
    }

}
