using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inspiration : MonoBehaviour {
    public int inspiration;
    public Text text;

    public int Get () {
        return inspiration;
    }
    public void Add (int num) {
        inspiration += num;
        text.text = inspiration.ToString();
    }
    public void Use(int num)
    {
        inspiration -= num;
        if (inspiration < 0){
            inspiration = 0;
        }
        text.text = inspiration.ToString();
	}
    public bool Check () {
        return inspiration > 0;
    }

}
