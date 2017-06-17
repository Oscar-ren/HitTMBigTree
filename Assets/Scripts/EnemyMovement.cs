using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;


	void Awake ()
	{
		player = GameObject.FindGameObjectsWithTag ("Player")[Random.Range(0, 2)].transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{
		GetComponent<Animator>().SetFloat("Speed", 1.0f);
		nav.SetDestination (player.position);
	}
}
