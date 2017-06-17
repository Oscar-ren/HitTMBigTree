using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour {

    private bool attack;
    private float lastAttackTime;
    public Animator animator;

	// Use this for initialization
	void Start () {
	}
	


	// Update is called once per frame
	void Update () {
        attack = false;
        if (Input.GetKeyDown(KeyCode.J)) {
            attack = true;
			switch (Random.Range(0, 4))
			{
				case 0:
					animator.SetTrigger("Attack 01");
					break;
				case 1:
					animator.SetTrigger("Attack 02");
					break;
				case 3:
					animator.SetTrigger("Double Attack");
					break;
				default:
					animator.SetTrigger("Jump Attack");
					break;
			}
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
