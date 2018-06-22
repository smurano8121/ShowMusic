using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenLoadScript : MonoBehaviour {

    public void SceneLoad() { 
        SceneManager.LoadScene("GameScene");
    }
}
