using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {
    Animator Anim;
    private bool AnimEnd = false;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("SkipAnim", 3f);
        if (Input.GetKeyDown("z"))
        {
            SkipAnim();
        }
        SceneLoad();
	}

    private void SceneLoad()
    {
        
        if (Input.GetKeyDown("z") && AnimEnd)
        {
           SceneManager.LoadScene(1);
        }
    }

    private void SkipAnim()
    {
        Anim.SetTrigger("skip");
        AnimEnd = true;
    }
}
