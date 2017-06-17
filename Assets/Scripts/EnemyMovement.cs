using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

	GameObject[] players;
	UnityEngine.AI.NavMeshAgent nav;


	void Awake ()
	{
//		player = GameObject.FindGameObjectsWithTag ("Player")[Random.Range(0, 2)].transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{

		players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject player = players[0];
		float minValue = 1000000f;;

		for(int i = 0; i < players.Length; i++)
		{
			Vector3 diff = players [i].transform.position - transform.position;
			if(diff.sqrMagnitude < minValue)
			{
				minValue = diff.sqrMagnitude;
				player = players [i];
			}
		}

		GetComponent<Animator>().SetFloat("Speed", 1.0f);
		nav.SetDestination (player.transform.position);
	}
}
