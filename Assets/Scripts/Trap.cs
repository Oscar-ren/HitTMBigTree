using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    public int damage = 50;

    private List<Collider> Cache;
    private void Awake()
    {
        Cache = new List<Collider>();
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.GetComponent<EnemyBattle>().BeAttacked(damage);
        }
        if (other.tag == "Player" ) {
            other.GetComponent<PlayerBattle>().BeAttecked(damage);
		}
    }
}
