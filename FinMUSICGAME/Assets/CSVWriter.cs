using UnityEngine;
using System.Collections;
using System.IO;

public class CSVWriter : MonoBehaviour {

    public string fileName;

	// Use this for initialization
	void Start () {
        //WriteCSV("helloworld");
	}

    public void WriteCSV(string txt) {
        StreamWriter streamwriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".txt");
        streamwriter = fileInfo.AppendText();
        streamwriter.WriteLine(txt);
        streamwriter.Flush();
        streamwriter.Close();
    }
}
