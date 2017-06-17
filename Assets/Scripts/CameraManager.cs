using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{


    public GameObject player1;
    public GameObject player2;

    Vector3 offset;

    void Start()
    {
        offset = new Vector3(-5f, 12f, 8f);
        transform.rotation = Quaternion.Euler(new Vector3(45f, 135f, 0f));
        Camera.main.fieldOfView = 60f;
        SetPos();

        //      Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth/2, 0));
        //      Vector3 pos2 = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
        //      MaxDistance = Mathf.Abs(Vector3.SqrMagnitude(pos - pos2));
        //Debug.Log(Camera.main.pixelWidth + "--" + Camera.main.pixelHeight);
        //Debug.Log(pos +"--"+pos2);

    }


    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = player1.transform.position + offset;
        SetPos();

	}

    void SetPos() {
        transform.position = (player1.transform.position + player2.transform.position) / 2 + offset;
    }

}
