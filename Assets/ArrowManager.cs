using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			Debug.Log ("Arrow Player");
//			other.gameObject.GetComponent
		}
	}
}
