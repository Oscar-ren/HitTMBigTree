using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	Animator anim;
	GameObject player;
//	PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;

	private bool isRotate;
	private Quaternion targetRotation;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
//		playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
		timer = timeBetweenAttacks;
	}


	void OnTriggerStay (Collider other)
	{
		if(other.tag == "Player")
		{
			transform.LookAt (other.transform.position);
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.tag == "Player")
		{
			playerInRange = false;
		}
	}

	void Attack ()
	{
		timer = 0f;
		anim.SetFloat("Speed", 0.0f);
		anim.SetTrigger ("Attack");

		if(gameObject.name == "Enemy_Archer")
		{
			// 弓箭手攻击不掉血，箭射到才掉血
		}

//		if(playerHealth.currentHealth > 0)
//		{
//			playerHealth.TakeDamage (attackDamage);
//		}
	}



	void Update () {

		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}

		//		if(playerHealth.currentHealth <= 0)
		//		{
		//			anim.SetTrigger ("PlayerDead");
		//		}
	}
}
