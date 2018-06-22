using UnityEngine;
using System.Collections;

public class NotesScript : MonoBehaviour {

    public int lineNum;
    private GameManager _gameManager;

	void Start () {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
        this.transform.position += Vector3.down * 10 * Time.deltaTime;
        Crash();
        if (this.transform.position.y < -5.0f) {
            //Debug.Log("false");
            Destroy(this.gameObject);
            _gameManager.BadTimingFunc();
        }
	}


    void Crash()
    {
        switch (lineNum){
            case 0:
                if (this.transform.position.y >= -1.0 && this.transform.position.y <= 0.4)
                {
                    if (this.transform.position.y >= -0.4 && this.transform.position.y <= 0)
                    {
                       // Debug.Log("excellent");
                        CheckExcellent(KeyCode.A);
                    }
                    else if ((this.transform.position.y >= -1.0 && this.transform.position.y < -0.4) || (this.transform.position.y > 0 && this.transform.position.y <= 0.4))
                    {
                        //Debug.Log("good");
                          CheckInput(KeyCode.A);
                    }
                }
                else { //Debug.Log("bad"); 
                    CheckBad(KeyCode.A); }
                break;
            case 1:
                if (this.transform.position.y >= -1.0 && this.transform.position.y <= 0.4)
                {
                    if (this.transform.position.y >= -0.4 && this.transform.position.y <= 0)
                    {
                       // Debug.Log("excellent");
                        CheckExcellent(KeyCode.S);
                    }
                    else if ((this.transform.position.y >= -1.0 && this.transform.position.y < -0.4) || (this.transform.position.y > 0 && this.transform.position.y <= 0.4))
                    {
                        //Debug.Log("good");
                        CheckInput(KeyCode.S);
                    }
                }
                else {// Debug.Log("bad");
                    CheckBad(KeyCode.S); }
                break;
            case 2:
                if (this.transform.position.y >= -1.0 && this.transform.position.y <= 0.4)
                {
                    if (this.transform.position.y >= -0.4 && this.transform.position.y <= 0)
                    {
                        //Debug.Log("excellent");
                        CheckExcellent(KeyCode.D);
                    }
                    else if ((this.transform.position.y >= -1.0 && this.transform.position.y < -0.4) || (this.transform.position.y > 0 && this.transform.position.y <= 0.4))
                    {
                        //Debug.Log("good");
                        CheckInput(KeyCode.D);
                    }
                }
                else { //Debug.Log("bad"); 
                    CheckBad(KeyCode.D); }
                break;
            case 3:
                if (this.transform.position.y >= -1.0 && this.transform.position.y <= 0.4)
                {
                    if (this.transform.position.y >= -0.4 && this.transform.position.y <= 0)
                    {
                       // Debug.Log("excellent");
                        CheckExcellent(KeyCode.F);
                    }
                    else if ((this.transform.position.y >= -1.0 && this.transform.position.y < -0.4) || (this.transform.position.y > 0 && this.transform.position.y <= 0.4))
                    {
                       // Debug.Log("good");
                        CheckInput(KeyCode.F);
                    }
                }
                else { //Debug.Log("bad"); 
                    CheckBad(KeyCode.F); }
                break;
            case 4:
                if (this.transform.position.y >= -1.0 && this.transform.position.y <= 0.4)
                {
                    if (this.transform.position.y >= -0.4 && this.transform.position.y <= 0)
                    {
                        //Debug.Log("excellent");
                        CheckExcellent(KeyCode.G);
                    }
                    else if ((this.transform.position.y >= -1.0 && this.transform.position.y < -0.4) || (this.transform.position.y > 0 && this.transform.position.y <= 0.4))
                    {
                        //Debug.Log("good");
                        CheckInput(KeyCode.G);
                    }
                }
                else { //Debug.Log("bad"); 
                    CheckBad(KeyCode.G); }
                break;
            default:
                break;
        }
    }

    void CheckInput(KeyCode key) {
        if (Input.GetKeyDown(key)) {
            _gameManager.GoodTimingFunc(lineNum);
            Destroy(this.gameObject);
        }
    }
    
    void CheckExcellent(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {

            _gameManager.ExcellentTimingFunc(lineNum);
            Destroy(this.gameObject);
        }
    }

    void CheckBad(KeyCode key) {
        if (Input.GetKeyDown(key)) {
            _gameManager.BadTimingFunc( );
        }
    }
}
