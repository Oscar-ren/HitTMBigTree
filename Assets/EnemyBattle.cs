﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour {
	public EnemyStatus Status;
	public int HP;
	public int Defense;
	public string EnemyName;

	void Start () {
        Status.SetFullHP(HP);
		Status.SetName(EnemyName);
	}

	public void Attacked (int damage) {
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
    public void Die () {
		GetComponent<Animator> ().SetTrigger ("isDead");
    }
}
