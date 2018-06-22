using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour {
    
    public Text scoreText;
	void Start () {
        int ttt = GameManager.GiveScore();
        Debug.Log(ttt);
        scoreText.text = ttt.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
