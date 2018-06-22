using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoosePush : MonoBehaviour
{
    private LightWriter _LightWriter;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 2 || transform.position.z < -2)
        {
            _LightWriter = GameObject.Find("LightWriter").GetComponent<LightWriter>();
            _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt", "500,500,500,500");
            Debug.Log("mmm");
            SceneManager.LoadScene("Choose Music");
        }
    }
}
