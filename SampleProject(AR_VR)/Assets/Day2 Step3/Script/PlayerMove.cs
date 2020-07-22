using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float fSpeed = 10f;
    float fRotSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fForward = Input.GetAxis("Vertical");
        float fTurn = Input.GetAxis("Horizontal");

        fForward = fForward * fSpeed * Time.deltaTime;
        fTurn = fTurn * fRotSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * fForward);
        transform.Rotate(Vector3.up * fTurn);
    }
}
