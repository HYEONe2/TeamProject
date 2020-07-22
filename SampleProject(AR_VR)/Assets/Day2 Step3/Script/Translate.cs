using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    Vector3 v3;

    // Start is called before the first frame update
    void Start()
    {
        v3 = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(v3);
    }
}
