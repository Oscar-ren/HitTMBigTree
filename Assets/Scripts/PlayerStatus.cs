using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerStatus : MonoBehaviour {
	public RectTransform HpBoxRect;
	public RectTransform HpRect;
	public Text Name;
	public int HP;
    public int currentHP;
	float FullWidth;
	public Text Count;

	// Use this for initialization
	void Start () {
		FullWidth = HpBoxRect.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHp (int hp) {
		currentHP = hp;
        Count.text = hp + "/" + HP;
		HpRect.DOSizeDelta(new Vector2(FullWidth * hp / HP, 0), 0.5f);
	}
    public void SetFullHp (int hp) {
		HP = hp;
        currentHP = hp;
		SetHp(hp);
    }
    public void SetName (string s) {
		Name.text = name;
	}
}
