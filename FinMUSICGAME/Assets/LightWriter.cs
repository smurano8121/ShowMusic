using UnityEngine;
using System.Collections;
using System.IO;

public class LightWriter : MonoBehaviour
{
    public string fileName;

    // Use this for initialization
    void Start(){
    }

    public void WriteCSV(string filepass,string txt){
        string str = System.IO.File.ReadAllText(filepass);
        str = txt;
        System.IO.File.WriteAllText(filepass,txt);
    }
}
