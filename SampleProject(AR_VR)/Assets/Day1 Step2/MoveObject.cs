using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float position = Input.GetAxis("Vertical");
        float HoriPosition = Input.GetAxis("Horizontal");

        position = position * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * position);

        HoriPosition = HoriPosition * speed * Time.deltaTime;
        transform.Translate(Vector3.right * HoriPosition);
    }
}
