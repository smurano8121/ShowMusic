using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WanimaChoose : MonoBehaviour
{
    public void WLoad()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("aaa");
    }
}

