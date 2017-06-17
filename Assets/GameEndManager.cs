using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour {

	public Image mask;
	public Text gameOver;
	public Button restart;
	public Button quit;

	void Start()
	{
		if (GameManager.isWin)
			Win ();
		else
			GameOver ();
	}

	public void GameOver()
	{
		gameOver.DOText ("失败!", 1).SetDelay (1);
		gameOver.DOText ("最终美术妹子和黑山老妖过上了幸福美满的生活", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				restart.gameObject.SetActive(true);
				quit.gameObject.SetActive(true);
			}
		);
	}

	public void Win()
	{
		gameOver.DOText (" 胜利!", 1).SetDelay (1);
		gameOver.DOText ("如果你愿意再来一遍的话", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				restart.gameObject.SetActive(true);
				quit.gameObject.SetActive(true);
			}
		);
	}
	
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
