using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour {
    public Inspiration Ins;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box") {
            Destroy(other.gameObject);
            Ins.Add(Random.Range(5,16));
        }
    }
}
