using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

	GameObject[] players;
	UnityEngine.AI.NavMeshAgent nav;
	public float maxDistance;
	public float frozenTime = 5f;

	public float frozenDuration = 5f;

	void Awake ()
	{
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		GetComponent<Animator>().SetFloat("Speed", 1.0f);
		maxDistance = 20;
	}


	void Update ()
	{
		frozenDuration += Time.deltaTime;
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
		nav.SetDestination (player.transform.position);

		if (minValue > Mathf.Pow(maxDistance, 2))
		{
			GetComponent<Animator>().SetFloat("Speed", 0.0f);
			nav.Stop ();
			return;
		}

		nav.Resume ();
	}

	public void StopAnimator()
	{
		GetComponent<Animator> ().speed = 0;
		nav.Stop ();
		frozenDuration = 0;

		Invoke ("ResumeAnimator", frozenTime);
	}

	public void ResumeAnimator()
	{
		if (frozenDuration < frozenTime)
			return;
		GetComponent<Animator> ().speed = 1f;
		nav.Resume ();
	}
}
