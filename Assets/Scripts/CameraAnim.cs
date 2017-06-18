using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour {
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	// Use this for initialization
	void Start () {
//        Fly();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Set (GameObject p, Vector3 pos, float x) {
        p.transform.position = pos;
        p.GetComponent<Animator>().SetTrigger("Victory");
        p.transform.rotation = Quaternion.Euler(new Vector3(0, x, 0));
    }

    public void Fly() {
        GetComponent<CameraManager>().enabled = false;
        GetComponent<Animator>().SetTrigger("Fly");
		Set(p1, new Vector3(-21.8f, -8.72f, 57.5f), -42.71f);
		Set(p2, new Vector3(-19.9f, -8.34f, 57.8f), -58);
		Set(p3, new Vector3(-25f, -8.67f, 54.41f), 5);
		Set(p4, new Vector3(-23f, -8.15f, 56.61f), -18.85f);
    }
}
