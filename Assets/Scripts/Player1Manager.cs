﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour {

	public Animator animator;

	private bool isRotate;
	private Quaternion targetRotation;

	public Transform player1;
	public Transform player2;
	float MaxDistance;

    public float Speed = 5;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		MaxDistance = Camera.main.pixelHeight * 2 / 3;
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

		if(Input.GetKeyDown(KeyCode.J))
		{
            
            switch(Random.Range(0, 4)) {
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

	void Move(Vector3 dir)
	{
		Vector3 pos = transform.position + dir * Time.deltaTime * Speed;

		Vector2 a = Camera.main.WorldToScreenPoint(pos);
		Vector2 b = Camera.main.WorldToScreenPoint(player2.position - dir * Time.deltaTime * Speed);

		float x = Camera.main.pixelWidth;
		float y = Camera.main.pixelHeight;
		if (a.x > 0 && a.x < x && a.y > 0 && a.y < y && b.x > 0 && b.x < x && b.y > 0 && b.y < y)
		{
			transform.position = pos;
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
