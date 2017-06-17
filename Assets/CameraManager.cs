using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject player;

	Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(0f,22f, -21f);
        transform.rotation = Quaternion.Euler(new Vector3(45f, 0f, 0f));
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
