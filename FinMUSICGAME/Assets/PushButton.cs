﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 2 || transform.position.z < -2)
        {
            Debug.Log("aaaa");
            SceneManager.LoadScene("Choose Music");
        }	
	}
}
