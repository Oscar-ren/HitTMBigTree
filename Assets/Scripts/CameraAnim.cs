﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour {
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject boss;
	// Use this for initialization
	void Start () {
        //        Fly();
        //StartAnm();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void StartAnm () {
		GetComponent<Animator>().SetTrigger("Start");
		Set(boss, new Vector3(-23.97f, 1.6f, 53.9f), 336.61f);
		Set(p3, new Vector3(-24.26f, 1.2f, 56.58f), -218.6f);
		Set(p4, new Vector3(-25.84f, 0.9f, 53.43f), 90);
    }
    void Set (GameObject p, Vector3 pos, float x) {
        p.transform.position = pos;
        p.transform.rotation = Quaternion.Euler(new Vector3(0, x, 0));
    }
    void Hit () {
		boss.GetComponent<Animator>().SetTrigger("Mellee");
    }

    public void Fly() {
        GetComponent<CameraManager>().enabled = false;
        GetComponent<Animator>().SetTrigger("Fly");
		Set(p1, new Vector3(-21.8f, 2.72f, 57.5f), -42.71f);
		Set(p2, new Vector3(-19.9f, 2.34f, 57.8f), -58);
		Set(p3, new Vector3(-25f, 2.67f, 54.41f), 5);
		Set(p4, new Vector3(-23f, 2.15f, 56.61f), -18.85f);
		p1.GetComponent<Animator>().SetTrigger("Victory");
		p2.GetComponent<Animator>().SetTrigger("Victory");
		p3.GetComponent<Animator>().SetTrigger("Victory");
		p4.GetComponent<Animator>().SetTrigger("Victory");
	}
}
