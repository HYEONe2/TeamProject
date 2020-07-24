using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    //Vector3 v3;
    float fSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //v3 = new Vector3(0, 1, 0);
        fSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        //    transform.Rotate(v3);
        //if (Input.GetKey(KeyCode.RightArrow))
        //    transform.Rotate(-v3);

        Vector3 vPos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
            vPos.x += fSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            vPos.x -= fSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            vPos.z -= fSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            vPos.z += fSpeed * Time.deltaTime;
        transform.position = vPos;
    }
}
