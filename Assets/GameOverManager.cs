using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Image mask;
	public Text gameOver;
	public Button restart;
	public Button quit;

	// Use this for initialization
	void Start () {
		gameOver.DOText ("失败!", 1).SetDelay (1);
		gameOver.DOText ("最终美术妹子和黑山老妖过上了幸福美满的生活", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				restart.gameObject.SetActive(true);
				quit.gameObject.SetActive(true);
			}
		);
	}
	
	// Update is called once per frame
	void Update () {
		if(mask.GetComponent<RectTransform> ().rect.height < 720)
			mask.GetComponent<RectTransform> ().sizeDelta =  new Vector2(0, mask.GetComponent<RectTransform> ().rect.height + 720 * Time.deltaTime);
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
