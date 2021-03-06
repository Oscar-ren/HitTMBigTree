﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class EnemyStatus : MonoBehaviour {

	public GameObject HpBox;
    public RectTransform HpRect;
    public Text Name;
    int HP;
    float FullWidth;

	void Awake () {
        FullWidth = HpBox.GetComponent<RectTransform>().rect.width;
	}
	
	void Update () {
        Vector3 op = gameObject.transform.parent.transform.parent.transform.position;
		float f = 2f;
		if (gameObject.transform.parent.transform.parent.name == "boss") {
			f = 4f;
		}
		Vector2 a = Camera.main.WorldToScreenPoint(new Vector3(op.x, op.y + f, op.z));
        gameObject.transform.position = a;
	}

    public void SetName (string name) {
        Name.text = name;
    }

    public void SetFullHP (int hp) {
        HP = hp;
        SetHp(hp);
    }
    public void SetHp(int hp) {
        HpRect.DOSizeDelta(new Vector2(FullWidth * hp / HP, 0), 0.5f);
    }

}
