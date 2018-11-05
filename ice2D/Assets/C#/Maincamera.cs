using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if(transform.position.x <= 0)
        {
            transform.position = new Vector3(0, transform.position.y, -10);
        }if(transform.position.y <= 15)
        {
            transform.position = new Vector3(transform.position.x, 0, -10);
        }
	}
}
