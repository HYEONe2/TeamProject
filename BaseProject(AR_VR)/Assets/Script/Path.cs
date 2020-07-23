using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vPos = transform.position;
        vPos.y = Terrain.activeTerrain.SampleHeight(transform.position) + 1f;
        transform.position = vPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
