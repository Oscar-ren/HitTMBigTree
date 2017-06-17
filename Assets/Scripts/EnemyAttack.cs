using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	Animator anim;
	GameObject player;
	EnemyBattle enemyBattle;
	bool playerInRange;
	float timer;

	private bool isRotate;
	private Quaternion targetRotation;


	void Awake ()
	{
		enemyBattle = GetComponent<EnemyBattle>();
		anim = GetComponent <Animator> ();
		timer = timeBetweenAttacks;
	}


	void OnTriggerStay (Collider other)
	{
		if(other.tag == "Player")
		{
			anim.SetFloat("Speed", 0.0f);
			player = other.gameObject;
			transform.LookAt (other.transform.position);
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.tag == "Player")
		{
			anim.SetFloat("Speed", 1.0f);
			player = null;
			playerInRange = false;
		}
	}

	void Attack ()
	{
		timer = 0f;
		anim.SetTrigger ("Attack");
		Invoke ("DamagePlayer", 0.7f);
	}

	void DamagePlayer()
	{
		if(player != null && gameObject.name.IndexOf("Enemy_Archer") < 0)
		{
			player.GetComponent<PlayerBattle> ().BeAttecked (attackDamage);
		}
	}



	void Update () {

		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange && enemyBattle.HP > 0)
		{
			Attack ();
		}
	}
}
