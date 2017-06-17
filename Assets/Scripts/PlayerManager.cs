﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Animator animator;

	private bool isRotate;
	private Quaternion targetRotation;


	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.W))
		{
			animator.SetBool ("Walk", true);
			transform.position = transform.position + Vector3.forward * Time.deltaTime * 3;
		}

		if(Input.GetKey(KeyCode.S))
		{
			animator.SetBool ("Walk", true);
			transform.position = transform.position - Vector3.forward * Time.deltaTime * 3;
		}

		if(Input.GetKey(KeyCode.A))
		{
			animator.SetBool ("Walk", true);
			transform.position = transform.position - Vector3.right * Time.deltaTime * 3;
		}

		if(Input.GetKey(KeyCode.D))
		{
			animator.SetBool ("Walk", true);
			transform.position = transform.position + Vector3.right * Time.deltaTime * 3;
		}

		if(Input.GetKeyDown(KeyCode.J))
		{
			animator.SetTrigger ("Rapid Attack");
		}

		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
		{
			animator.SetBool ("Walk", false);
		}


		if(Input.GetKey(KeyCode.Space))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up);
		}


		if (Input.GetKey(KeyCode.A))
		{
			SwitchTurn (-90f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			SwitchTurn (90f);
		}
		if (Input.GetKey(KeyCode.W))
		{
			SwitchTurn (0);
		}
		if (Input.GetKey(KeyCode.S))
		{
			SwitchTurn (180f);
		}

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)) {
			SwitchTurn (-45f);
		}

		if (Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)) {
			SwitchTurn (45f);
		}
		
	}

	IEnumerator TempCoroutine;

	IEnumerator Turn(Quaternion targetRotation)
	{
		while(Quaternion.Angle(targetRotation, transform.rotation) > 1)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
			yield return null;
		}
		transform.rotation = targetRotation;
	}

	void SwitchTurn(float yDir)
	{
		targetRotation = Quaternion.Euler(0, yDir, 0) * Quaternion.identity;
		if(TempCoroutine != null)
			StopCoroutine (TempCoroutine);
		TempCoroutine = Turn (targetRotation);
		StartCoroutine (TempCoroutine);
	}

	void FixedUpdate()
	{
		
	}

}
