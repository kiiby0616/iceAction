using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBer : MonoBehaviour {
    Slider slinder;
    private float hp = 0;

	// Use this for initialization
	void Start () {
        slinder = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slinder.value = hp;
	}

    public void Damage(float damage)
    {
        hp += damage;
    }
}
