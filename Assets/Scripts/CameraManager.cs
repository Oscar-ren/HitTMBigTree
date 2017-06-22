using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    public GameObject player1;

    Vector3 offset;

    void Start()
    {

        offset = new Vector3(1.5f, 10f, 4.5f);
        transform.rotation = Quaternion.Euler(new Vector3(45f, 180f, 0f));
        Camera.main.fieldOfView = 60f;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player1.transform.position + offset;
		transform.rotation = Quaternion.Euler(new Vector3(45f, 180f, 0f));
	}


}
