﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RADPush : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 2 || transform.position.z < -2)
        {
            Debug.Log("rrr");
            SceneManager.LoadScene("GameScene3");
        }
    }
}
