﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour {

    public Animator animator;

    private bool isRotate;
    private Quaternion targetRotation;

    public Transform player1;
	public Transform player2;

	float MaxDistance;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator> ();
		MaxDistance = Camera.main.pixelHeight * 2 / 3;
	}
    
    // Update is called once per frame
    void Update () {

        if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool ("Walk", true);
			Move(-Vector3.forward);
		}

        if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool ("Walk", true);
			Move(Vector3.forward);
		}

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool ("Walk", true);
			Move(Vector3.right);
		}

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool ("Walk", true);
			Move(-Vector3.right);
		}

        if(Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger ("Projectile Attack");
        }
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			animator.SetBool("Walk", false);
		}


        if (Input.GetKey(KeyCode.LeftArrow))
		{
			SwitchTurn(90f);
		}
        if (Input.GetKey(KeyCode.RightArrow))
		{
			SwitchTurn(-90f);
		}
        if (Input.GetKey(KeyCode.UpArrow))
		{
			SwitchTurn(180f);
		}
        if (Input.GetKey(KeyCode.DownArrow))
		{
			SwitchTurn(0f);
		}

		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SwitchTurn(135f);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SwitchTurn(225f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SwitchTurn(45f);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SwitchTurn(315f);
        }



	}

	void Move(Vector3 dir)
	{
        Vector3 pos = transform.position + dir * Time.deltaTime * 3;

		Vector2 a = Camera.main.WorldToScreenPoint(pos);
		Vector2 b = Camera.main.WorldToScreenPoint(player1.position - dir * Time.deltaTime * 3);

		float x = Camera.main.pixelWidth;
        float y = Camera.main.pixelHeight;
        if (a.x > 0 && a.x < x && a.y > 0 && a.y < y && b.x > 0 && b.x < x && b.y > 0 && b.y < y) {
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
