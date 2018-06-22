using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour {

    Slider _slider;
	void Start () {
        _slider = GameObject.Find("HP").GetComponent<Slider>();
	}

    float _hp = 0;
	void Update () {
        _hp += 1.0f;
        if (_hp > 50) {
            _hp = 0;
        }
        _slider.value = _hp;
	}
}
