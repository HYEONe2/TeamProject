using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    AudioSource collisionSound;

    // Start is called before the first frame update
    void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("COLLISION");
        collisionSound.Play();
    }
}
