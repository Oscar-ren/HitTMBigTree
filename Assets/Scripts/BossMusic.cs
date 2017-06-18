using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour {

    private bool isMusic;
    public AudioClip ac;
    public AudioSource sm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isMusic) {
            isMusic = true;
            sm.clip = ac;
            sm.Play();
        }
    }

}
