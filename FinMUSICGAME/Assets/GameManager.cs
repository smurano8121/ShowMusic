using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public GameObject[] notes;
    public GameObject[] goodeffects;
    public GameObject[] excellenteffects;
    private float[] _timing;
    private int[] _lineNum;

    public string filePass;
    private int _notesCount = 0;

    private AudioSource _audioSource;
    private float _startTime = 0;

    public float timeOffset = -2.1f;

    private bool _isPlaying = false;
    public GameObject startButton;

    public Text scoreText;
    public static int _score = 0;
    private int score = 50; //HP管理
    private int combo = 0;
    public static int maxcombo = 0;

    Slider _slider;
    Slider _slideryellow;
    Slider _sliderred;
    float _hp = 0;

    private LightWriter _LightWriter;

    //ゲームを取り込んだり初期設定を行う
	void Start () {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _slider = GameObject.Find("HP").GetComponent<Slider>();
        _slideryellow = GameObject.Find("HPYellow").GetComponent<Slider>();
        _sliderred = GameObject.Find("HPRed").GetComponent<Slider>();
        _LightWriter = GameObject.Find("LightWriter").GetComponent<LightWriter>();
        _slider.value = 0;
        _timing = new float[1024];
        _lineNum = new int[1024];
        _score = 0;
        maxcombo = 0;
        _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt","500,500,500,500");
        LoadCSV();
	}

    //実行すると繰り返される
    void Update() {
        if (_isPlaying)
        {
            CheckNextNotes();
            _score += combo*10;
            scoreText.text = _score.ToString();
            if (score <= 0) { SceneManager.LoadScene("GameOver"); }
            else if (score > 20) { _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt", "10,200,10,10"); }
            else if (score <= 20 && score > 10) { _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt", "0,0,0,400"); }
            else if (score <10) { _LightWriter.WriteCSV("Assets/Resources/Light/Color.txt", "200,10,10,10"); }
        }
        if (!_audioSource.isPlaying && _isPlaying == true) {
            StartCoroutine(WaitAndGo());
            SceneManager.LoadScene("GameClear"); 
        }
    }

    //ゲームが始まるのを待つ（ボタン待ち）
    public void StartGame() {
        startButton.SetActive(false);
        _startTime = Time.time;
        _audioSource.Play();
        _isPlaying = true;
    }

    void CheckNextNotes() {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0) {
            SpawnNotes(_lineNum[_notesCount]); //n番目の音符のラインを送る（0列目～4列目）
            _notesCount++;
        }
    }

    IEnumerator WaitAndGo() {
        yield return new WaitForSeconds(10.0f); 
    }

    //音符を生成する
    void SpawnNotes(int num) {
        Instantiate(notes[num], new Vector3(-4.0f + (2.0f * num), 10.0f, 0), Quaternion.identity);
    }

    //CSVファイルを読み込む
    void LoadCSV()
    {
        int i = 0, j;
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
    }

    //今の時間を管理する
    float GetMusicTime() {
        return Time.time - _startTime;
    }

    public void ExcellentTimingFunc(int num)
    {
        _score += 100;
        combo += 1;
        Instantiate(excellenteffects[num], new Vector3(-4.0f + (2.0f * num), 0, 0), Quaternion.identity);
        //Debug.Log("Excellent!");
        if (score <= 49)
        {
            score += 1;
            _hp -= 1.0f;
        }
        if (_hp < 31)
        {
            _slider.value = _hp;
        }
        else if (_hp >= 31 && _hp < 41)
        {
            _slideryellow.value = _hp;
        }
        else { _sliderred.value = _hp; }
    }

    //タイミングがgoodだったら呼び出される
    public void GoodTimingFunc(int num) {
        combo += 1;
        Instantiate(goodeffects[num], new Vector3(-4.0f + (2.0f * num), 0, 0), Quaternion.identity);
        if (score <= 49)
        {
            score += 1;
            _hp -= 1.0f;
        }
        if (_hp < 31)
        {
            _slider.value = _hp;
        }
        else if (_hp >= 31 && _hp < 41)
        {
            _slideryellow.value = _hp;
        }
        else { _sliderred.value = _hp; }   
    }

    public void BadTimingFunc( ) 
    {
        if (combo > maxcombo) { maxcombo = combo; }
        combo = 0;
        //Debug.Log(GetMusicTime());
        score--;
        _hp += 1.0f;
        if (_hp < 31)
        {
            _slider.value = _hp;
        }
        else if (_hp >= 31 && _hp < 41)
        {
            _slideryellow.value = _hp;
        }
        else { _sliderred.value = _hp; }
    }

    public static int GiveScore(){
        return _score;
    }

    public static int GiveMax() {
        return maxcombo;
    }
}