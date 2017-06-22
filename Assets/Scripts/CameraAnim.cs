using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour {
	public GameObject p1;
	public GameObject p3;
	public GameObject p4;
	public GameObject boss;
    public Player1Manager P1M;

    public ETCJoystick JoyStick;

    private CameraManager CM;
	// Use this for initialization
	void Start () {
		//        Fly();
		CM = GetComponent<CameraManager>();

		StartAnm();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartAnm () {
        JoyStick.enableCamera = false;
		GetComponent<Animator>().SetTrigger("Start");
		Set(boss, new Vector3(-23.97f, 1.6f, 53.9f), 336.61f);
		Set(p3, new Vector3(-24.26f, 1.2f, 56.58f), -218.6f);
		Set(p4, new Vector3(-25.84f, 0.9f, 53.43f), 90);
        P1M.enabled = false;
    }

    void ResetP(){
		Set(p4, new Vector3(-26.899f, 0.9f, 45.2f), -90);
		Set(p3, new Vector3(-26.28f, 0.9f, 46.14f), 0);
		P1M.enabled = true;
	}
    void Set (GameObject p, Vector3 pos, float x) {
        p.transform.position = pos;
        p.transform.rotation = Quaternion.Euler(new Vector3(0, x, 0));
    }
    void Hit () {
		boss.GetComponent<Animator>().SetTrigger("Mellee");
    }

    void EnableCM (){
		JoyStick.enableCamera = true;
	}

	void TakeEnd() {
		GameManager.LoadEndScene (true);
		Camera.main.GetComponent<AudioSource> ().Stop ();
	}

    public void Fly() {
		GameObject.Find("Enemies").SetActive(false);
		CM.enabled = false;
        GetComponent<Animator>().SetTrigger("Fly");
		Set(p1, new Vector3(-21.8f, 2.72f, 57.5f), -42.71f);
		Set(p3, new Vector3(-25f, 1, 54.41f), 5);
		Set(p4, new Vector3(-23f, 1, 56.61f), -18.85f);
		p1.GetComponent<Animator>().SetTrigger("Victory");
		p3.GetComponent<Animator>().SetTrigger("Victory");
		p4.GetComponent<Animator>().SetTrigger("Victory");
	}
}
