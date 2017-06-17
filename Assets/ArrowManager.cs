using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

	public int attackDamage = 10;

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerBattle> ().BeAttecked (attackDamage);
		}
	}
}
