using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBattle : MonoBehaviour {
	public PlayerStatus Status;
	public int HP = 1000;
    public string Name;
	public int Defense;

	void Start () {
        Status.SetFullHp(HP);
        Status.SetName(Name);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -20f)
			Die ();
	}

	public void BeAttecked (int damage) {

		if (damage < Defense)
			damage = Defense;
		
		HP -= damage - Defense;
        if (HP <= 0) {
            HP = 0;
            Status.SetHp(HP);
            Die();
        } else {
            Status.SetHp(HP);
        }

    }
    void Die () {
		GameManager.LoadEndScene (false);
    }
}
