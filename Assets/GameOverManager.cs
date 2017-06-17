using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverManager : MonoBehaviour {

	public Image Mask;
	public Text GameOver;
	public Button Restart;
	public Button Quit;

	// Use this for initialization
	void Start () {
		GameOver.DOText ("失败!", 1).SetDelay (1);
		GameOver.DOText ("最终美术妹子和黑山老妖过上了幸福美满的生活", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				Restart.gameObject.SetActive(true);
				Quit.gameObject.SetActive(true);
			}
		);
	}
	
	// Update is called once per frame
	void Update () {
		if(Mask.GetComponent<RectTransform> ().rect.height < 720)
			Mask.GetComponent<RectTransform> ().sizeDelta =  new Vector2(0, Mask.GetComponent<RectTransform> ().rect.height + 720 * Time.deltaTime);
	}
}
