using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : MonoBehaviour {

    public float life_time = 0.2f;
    float time = 0f;
	
    void Start () {
        time = 0;	
	}
	
	void Update () {
        time += Time.deltaTime;
        if (time > life_time) {
            Destroy(this.gameObject);
        }
	}
}
