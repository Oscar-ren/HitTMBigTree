using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public GameObject Menu;
	public GameObject Introduce;

	public Image menuImage;
	public Image introImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		Menu.SetActive (false);
		menuImage.gameObject.SetActive (false);
		Introduce.SetActive (true);
		introImage.gameObject.SetActive (true);

		Invoke ("Begin", 4f);
	}

	void Begin()
	{
		SceneManager.LoadScene ("Scene1");
	}
}
