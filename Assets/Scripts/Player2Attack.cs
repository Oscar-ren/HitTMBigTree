using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour {
    private bool attack;
    public Inspiration Ins;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		attack = false;
        if (Input.GetKeyDown(KeyCode.Return))
		{
			attack = true;
		}
	}
	private void OnTriggerStay(Collider other)
	{

		if (other.tag == "Enemy" && attack)
		{
			if (Ins.Check())
			{
				Ins.Use(10);
				other.GetComponent<EnemyMovement>().StopAnimator();
			}
		}
	}

}
