using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaxCombo : MonoBehaviour
{

    public Text MaxText;
    void Start()
    {
        int ttt = GameManager.GiveMax();
        Debug.Log(ttt);
        MaxText.text = ttt.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
