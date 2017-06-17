using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour {
	public EnemyStatus Status;
	public int HP = 500;
	public string EnemyName;

	void Start () {
        Status.SetFullHP(HP);
		Status.SetName(EnemyName);
	}

    public void Attacked (int h = 100) {
		HP -= h;
		if (HP <= 0) {
            HP = 0;
			Status.SetHp(HP);
			Die();
        } else {
			Status.SetHp(HP);
		}

    }
    public void Die () {
        Debug.Log("Enemy Die");
    }
}
