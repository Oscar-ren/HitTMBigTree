using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SuperSkill : MonoBehaviour {

	public GameObject prefab;
	public int minBlood = 100;
	private bool isTriggerHuge;

	void Start () {
		
	}
	
	void Update () {

		if(gameObject.name == "Enemy_Necro" && GetComponent<EnemyBattle>().HP < minBlood && isTriggerHuge != true)
		{
			isTriggerHuge = true;
			gameObject.transform.DOScale (new Vector3 (1.8f, 1.8f, 1.8f), 2).SetEase(Ease.InQuad);
			GetComponent<EnemyAttack>().attackDamage = GetComponent<EnemyAttack>().attackDamage * 2 / 3;
			GetComponent<EnemyAttack>().timeBetweenAttacks = GetComponent<EnemyAttack>().timeBetweenAttacks * 3 / 2;
			GetComponent<triggerProjectile> ().hitEffect = prefab;
		}
	}
}
