using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    private Text text;
    private float Score =0;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "SCORE:"+Score;
	}

    public void ScorePlus(float a)
    {
        Score += a;
    }
}
