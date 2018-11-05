using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Picked : MonoBehaviour {
    public GameObject iceblock;
    private bool icede= false;
    Rigidbody2D rd2D;


	// Use this for initialization
	void Start () {
        rd2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Ptama" && icede == false)
        {
            GameObject block = Instantiate(this.iceblock, transform.position, transform.rotation);
            block.transform.parent = transform;
            icede = true;
            
        }
        
    }

    

}
