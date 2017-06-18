using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
	public EnemyStatus Status;
	public AudioClip beAttackedClip;
	public AudioClip deathClip;
	public int HP;
	public int Defense;
	public string EnemyName;

	void Start()
	{
		Status.SetFullHP(HP);
		Status.SetName(EnemyName);
	}

	public void BeAttacked(int damage)
	{
//		GetComponent<SoundManager> ().PlaySingle (beAttackedClip);
		if (damage < Defense)
			damage = Defense;

		HP -= damage - Defense;
		if (HP <= 0)
		{
			HP = 0;
			Status.SetHp(HP);
			Die();
		}
		else
		{
			Status.SetHp(HP);
		}
	}
	public void Die()
	{
		GetComponent<SoundManager> ().PlaySingle (deathClip);
		GetComponent<Animator>().SetTrigger("isDead");
		Invoke("DestoryEnemy", 1f);
	}

	void DestoryEnemy()
	{
		Destroy(gameObject);
	}
}
