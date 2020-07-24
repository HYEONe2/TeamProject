using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMoving : MonoBehaviour
{
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "Wall")
            GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
