using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    private bool attack;
    private float lastAttackTime;

	// Use this for initialization
	void Start () {
	}
	


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) {
            attack = true;
        }
	}
    private void OnTriggerStay(Collider other)
    {
		if(other.tag == "Enemy" && attack && Time.timeSinceLevelLoad - lastAttackTime > 1) {
            Debug.Log("attack enemy");
            other.GetComponent<EnemyBattle>().Attacked();
            lastAttackTime = Time.timeSinceLevelLoad;
        }
        attack = false;
	}
}
