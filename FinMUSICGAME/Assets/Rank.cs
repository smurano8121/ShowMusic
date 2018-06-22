using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rank : MonoBehaviour
{

    public Text scoreText;
    void Start()
    {
        int ttt = GameManager.GiveScore();
        if (ttt >= 600000) { scoreText.text = "S"; }
        else if (ttt < 600000 && ttt >= 500000) { scoreText.text = "A"; }
        else if (ttt < 500000 && ttt >= 300000) { scoreText.text = "B"; }
        else if (ttt < 300000 && ttt >= 150000) { scoreText.text = "C"; }
        else if (ttt < 150000 && ttt >= 100000) { scoreText.text = "D"; }
        else if (ttt == 0) { scoreText.text = "未挑戦"; }
        else { scoreText.text = "F"; }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
