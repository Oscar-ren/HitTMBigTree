using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

	public static bool isEnd = false;
	public static bool isWin;

	public static void Reset()
	{
		isEnd = false;
		isWin = false;
	}

	public static void LoadEndScene(bool hasWin)
	{
		isWin = hasWin;
		if(isEnd == false)
			SceneManager.LoadScene ("GameEnd", LoadSceneMode.Additive);
		isEnd = true;
	}
}
