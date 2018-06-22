using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackChoose : MonoBehaviour {

    private LightWriter _LightWriter;
    public void RLoad()
    {
        _LightWriter = GameObject.Find("LightWriter").GetComponent<LightWriter>();
        _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt", "500,500,500,500");
        SceneManager.LoadScene("Choose Music");
        //Debug.Log("aaa");
    }
}
