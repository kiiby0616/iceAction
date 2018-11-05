using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemy;
    Vector3 GOJpos;
    public LayerMask SpawnCenser;
    private bool check;
    private bool oneenemy;
    // Use this for initialization
    void Start () {
        GOJpos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        Check();
        
	}
    void Check()
    {
        check = Physics2D.Linecast(
            new Vector3(GOJpos.x, GOJpos.y + 10f), new Vector3(GOJpos.x, GOJpos.y - 10f), SpawnCenser);
        if (check )
        {
            
            if (!gameObject.HasChild() && oneenemy==false)
            {
                oneenemy = true;
                Debug.Log("Spawn!");
                GameObject enemy = Instantiate(this.enemy, transform.position, transform.rotation);
                enemy.transform.parent = transform;
            }
            
        }else if (!check)
        {
            oneenemy = false;
        }
    }
    
}
