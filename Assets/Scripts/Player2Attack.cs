using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour {
    private bool attack;
    public Inspiration Ins;
	public Animator animator;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update()
	{
		attack = false;
		if (Input.GetKeyDown(KeyCode.Return))
		{
            if (Ins.Check(10)){
				animator.SetTrigger("Projectile Attack");
				Ins.Use(10);
				attack = true;
			}
		}
	}
	private void OnTriggerStay(Collider other)
	{
        if (other.tag == "Trap" && attack) {
            Destroy(other.gameObject);
        }
		if (other.tag == "Enemy" && attack)
		{
			other.GetComponent<EnemyMovement>().StopAnimator();
		}
	}

}
