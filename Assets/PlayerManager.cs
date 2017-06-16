using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.W))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward);
		}

		if(Input.GetKey(KeyCode.S))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.back);
		}

		if(Input.GetKey(KeyCode.A))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.left);
		}

		if(Input.GetKey(KeyCode.D))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right);
		}

		if(Input.GetKey(KeyCode.Space))
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up);
		}
		
	}
}
