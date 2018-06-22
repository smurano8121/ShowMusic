using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Leap;

public class CScenemove : MonoBehaviour
{
    public void SceneLoad()
    {
        SceneManager.LoadScene("Choose Music");
    }
}
