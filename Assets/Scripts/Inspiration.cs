using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspiration : MonoBehaviour {
    public int inspiration;

    public int Get () {
        return inspiration;
    }
    public void Add (int num) {
        inspiration += num;
    }
    public void Use(int num)
    {
        inspiration -= num;
        if (inspiration < 0)
            inspiration = 0;
    }
    public bool Check () {
        return inspiration > 0;
    }

}
