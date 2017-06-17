using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBattle : MonoBehaviour {
	public PlayerStatus Status;
	public int HP = 1000;
    public string Name;
	// Use this for initialization
	void Start () {
        Status.SetFullHp(HP);
        Status.SetName(Name);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -20f)
			Die ();
	}

    public void BeAttecked (int h = 100) {

        HP -= h;
        if (HP <= 0) {
            HP = 0;
            Status.SetHp(HP);
            Die();
        } else {
            Status.SetHp(HP);
        }

    }
    void Die () {
        Debug.Log("player die");
		SceneManager.LoadScene ("GameOver", LoadSceneMode.Additive);
    }
}
