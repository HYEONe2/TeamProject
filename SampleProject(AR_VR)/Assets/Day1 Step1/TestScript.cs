using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    int iValue;
    float fValue;
    bool bValue;
    string sValue;

    // Start is called before the first frame update
    void Start()
    {
        iValue = 50;
        fValue = 100.23f;
        bValue = true;
        sValue = "Hello~";
    }

    // Update is called once per frame
    void Update()
    {
        print("Integer Value: " + iValue);
        print("Float Value: " + fValue);
        print("Bool Value: " + bValue);
        print("String Value: " + sValue);
    }
}
