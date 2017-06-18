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
	public AudioClip winClip;
	public AudioClip gameOverClip;

	void Start()
	{
		if (GameManager.isWin)
			Win ();
		else
			GameOver ();
	}

	public void GameOver()
	{
		GetComponent<SoundManager> ().PlaySingle (gameOverClip);
		gameOver.DOText (" 失败! ", 1).SetDelay (1);
		gameOver.DOText ("策划不死，这游戏是玩不过去了", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				restart.gameObject.SetActive(true);
				quit.gameObject.SetActive(true);
			}
		);
	}

	public void Win()
	{
		GetComponent<SoundManager> ().PlaySingle (winClip);
		gameOver.DOText (" 胜利! ", 1).SetDelay (1);
		gameOver.DOText ("玩呢，这游戏对爷来说就是小菜一碟", 3).SetDelay (2).SetEase(Ease.Linear).OnComplete(
			() => {
				restart.gameObject.SetActive(true);
				quit.gameObject.SetActive(true);
			}
		);
	}
	
	void Update () {
		if(mask.GetComponent<RectTransform> ().rect.height < 1080)
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
