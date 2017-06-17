using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {

	public static bool isOver = false;

	public static void GameOver()
	{
		if(isOver == false)
			SceneManager.LoadScene ("GameOver", LoadSceneMode.Additive);
		isOver = true;
	}
}
