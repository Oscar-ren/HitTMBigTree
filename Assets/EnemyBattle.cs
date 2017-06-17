using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour {
    public int HP = 500;
	private EnemyStatus Status;
	// Use this for initialization
	void Start () {
		Status = transform.Find("EnemyStatus/Status").GetComponent<EnemyStatus>();
        Status.FullHp(HP);
        Status.SetName("树妖");
	}
	
	// Update is called once per frame
	void Update () {
		
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
