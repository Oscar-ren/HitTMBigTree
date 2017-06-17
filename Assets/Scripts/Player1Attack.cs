using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour {

    private bool attack;
    private float lastAttackTime;

	// Use this for initialization
	void Start () {
	}
	


	// Update is called once per frame
	void Update () {
        attack = false;
        if (Input.GetKeyDown(KeyCode.J)) {
            attack = true;
        }
	}
    private void OnTriggerStay(Collider other)
    {

		if(other.tag == "Enemy" && attack && Time.timeSinceLevelLoad - lastAttackTime > 1) {
            other.GetComponent<EnemyBattle>().BeAttacked(10);
            lastAttackTime = Time.timeSinceLevelLoad;
			attack = false;
        }
	}
}
