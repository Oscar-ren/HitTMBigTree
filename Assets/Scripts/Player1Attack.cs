﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour {

	public int damage = 10;

    private bool attack;
    private float lastAttackTime;
    public Animator animator;

	public Inspiration Ins;

	public bool DoubleDamage = false;

    public ParticleSystem DoubleAnim;

	// Use this for initialization
	void Start () {
	}
	

    void CancelDoubleDamage () {
        DoubleAnim.Stop();
        DoubleDamage = false;
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) {
            attack = true;
			switch (Random.Range(0, 4))
			{
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
        if (Input.GetKeyDown(KeyCode.K)) {
				if (Ins.Check(10))
				{
					Ins.Use(10);
					DoubleDamage = true;
                    Invoke("CancelDoubleDamage", 5f);
                    DoubleAnim.Play();
				}
        }
	}
    Dictionary<Collider, float> cache = new Dictionary<Collider, float> ();
    public void Attack () {
		attack = true;
        Invoke("ResetFlag", 0.3f);
		switch (Random.Range(0, 4))
		{
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
    public void DoubleAttack() {

		if (Ins.Check(10))
		{
			Ins.Use(10);
			DoubleDamage = true;
			Invoke("CancelDoubleDamage", 5f);
			DoubleAnim.Play();
		}
    }
    void ResetFlag() {
		attack = false;
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy") {
            float val;
            cache.TryGetValue(other, out val);
			if (val == 0) {
				cache[other] = 0;
			}
        }
		if(other.tag == "Enemy" && attack && Time.timeSinceLevelLoad - cache[other] > 1) {
			other.GetComponent<EnemyBattle>().BeAttacked(DoubleDamage ? damage * 2 : damage);
            cache[other] = Time.timeSinceLevelLoad;
        }
	}
}
