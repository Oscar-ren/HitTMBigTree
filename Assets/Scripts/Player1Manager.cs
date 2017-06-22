﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour {

	public Animator animator;

	private bool isRotate;
	private Quaternion targetRotation;

	public Transform player1;

    public float Speed = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        isRotate = false;
		if(Input.GetKey(KeyCode.W))
		{
			animator.SetBool ("Run", true);
            Move(-Vector3.forward);
		}

		if(Input.GetKey(KeyCode.S))
		{
			animator.SetBool ("Run", true);
			Move(Vector3.forward);
		}

		if(Input.GetKey(KeyCode.A))
		{
			animator.SetBool ("Run", true);
            Move(Vector3.right);
		}

		if(Input.GetKey(KeyCode.D))
		{
			animator.SetBool ("Run", true);
            Move(-Vector3.right);
		}


		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
		{
			animator.SetBool ("Run", false);
		}


		if (Input.GetKey(KeyCode.A))
		{
			SwitchTurn (90f);
		}
		if (Input.GetKey(KeyCode.D))
		{
			SwitchTurn (-90f);
		}
		if (Input.GetKey(KeyCode.W))
		{
			SwitchTurn (180f);
		}
		if (Input.GetKey(KeyCode.S))
		{
			SwitchTurn (0f);
		}

		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
		{
			SwitchTurn(135f);
		}

		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
		{
			SwitchTurn(225f);
		}
		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
		{
			SwitchTurn(45f);
		}

		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
		{
			SwitchTurn(315f);
		}


	}

    public void TouchDir(Vector2 v) {
		animator.SetBool("Run", true);
		transform.LookAt(transform.position - new Vector3(v.x,0,v.y));
        
    }
    public void TouchEnd () {
		animator.SetBool("Run", false);
	}
	void Move(Vector3 dir)
	{
		transform.position = transform.position + dir * Time.deltaTime * Speed;

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
