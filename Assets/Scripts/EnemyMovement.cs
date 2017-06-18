using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour {

	GameObject[] players;
	UnityEngine.AI.NavMeshAgent nav;


	public float maxDistance = 20f;
	public float frozenTime = 5f;
	public bool isFrozen = false;

	public GameObject windPrefab;

	private float frozenDuration = 0;
	private GameObject wind;

	void Awake ()
	{
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		GetComponent<Animator>().SetFloat("Speed", 1.0f);
	}


	void Update ()
	{
		if (frozenDuration > 0.2)
			frozenDuration -= Time.deltaTime;
		else
			isFrozen = false;

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

		if(isFrozen == false)
		{
			GetComponent<Animator>().SetFloat("Speed", 1.0f);
			nav.Resume ();
		}

		if(Input.GetKeyDown(KeyCode.M))
		{
			StopAnimator ();
		}
	}

	public void StopAnimator()
	{
		GetComponent<Animator> ().speed = 0;
		nav.Stop ();

		if(isFrozen == false)
		{
			wind = Instantiate (windPrefab, transform);
			wind.transform.localPosition = Vector3.zero;
		}
		frozenDuration = 5f;
		isFrozen = true;
		Invoke ("ResumeAnimator", frozenTime);
	}

	public void ResumeAnimator()
	{
		if (isFrozen)
			return;
		Destroy (wind);
		GetComponent<Animator> ().speed = 1f;
		nav.Resume ();
	}
}
