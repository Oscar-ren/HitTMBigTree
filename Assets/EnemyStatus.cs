using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class EnemyStatus : MonoBehaviour {

	GameObject HpBox;
    RectTransform HpRect;
    Text Name;
    int HP;
    float FullWidth;
	// Use this for initialization
	void Start () {

		HpBox = transform.Find("HpBox").gameObject;
        HpRect = transform.Find("HpBox/Hp").GetComponent<RectTransform>();
        FullWidth = HpBox.GetComponent<RectTransform>().rect.width;
        Name = transform.Find("Name").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 op = gameObject.transform.parent.transform.parent.transform.position;
        Vector2 a = Camera.main.WorldToScreenPoint(new Vector3(op.x, op.y + 2f, op.z));
        gameObject.transform.position = a;
	}

    public void SetName (string name) {
        Name.text = name;
    }

    public void FullHp (int hp) {
        HP = hp;
        SetHp(hp);
    }
    public void SetHp(int hp) {
        HpRect.DOSizeDelta(new Vector2(FullWidth * hp / HP, 0), 0.5f);
    }

}
