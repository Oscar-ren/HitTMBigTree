﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour {

    public Animator animator;

    private bool isRotate;
    private Quaternion targetRotation;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator> ();
    }
    
    // Update is called once per frame
    void Update () {

        if(Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool ("Walk", true);
            transform.position = transform.position + Vector3.forward * Time.deltaTime * 3;
		}

        if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool ("Walk", true);
            transform.position = transform.position - Vector3.forward * Time.deltaTime * 3;
		}

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool ("Walk", true);
            transform.position = transform.position - Vector3.right * Time.deltaTime * 3;
		}

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool ("Walk", true);
            transform.position = transform.position + Vector3.right * Time.deltaTime * 3;
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
			SwitchTurn(-90f);
		}
        if (Input.GetKey(KeyCode.RightArrow))
		{
			SwitchTurn(90f);
		}
        if (Input.GetKey(KeyCode.UpArrow))
		{
			SwitchTurn(0);
		}
        if (Input.GetKey(KeyCode.DownArrow))
		{
			SwitchTurn(180f);
		}

		if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SwitchTurn(-45f);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            SwitchTurn(45f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SwitchTurn(175f);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            SwitchTurn(135f);
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
