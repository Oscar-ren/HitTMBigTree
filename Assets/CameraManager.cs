using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject player;

	Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(8.5f, 12.7f, -9.5f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
