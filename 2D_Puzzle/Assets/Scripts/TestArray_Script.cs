using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArray_Script : MonoBehaviour
{
    public List<int> array_test = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        array_test.Add(10);
        array_test.Add(20);
        array_test.Add(30);

        //Debug.Log("array_test[0]: " + array_test[0]);
        //Debug.Log("array_test[1]: " + array_test[1]);
        //Debug.Log("array_test[2]: " + array_test[2]);

        //// C++ 스타일
        //for (int i = 0; i < array_test.Count; ++i)
        //    Debug.Log(array_test[i]);

        //// 최신 언어 스타일
        //foreach (int value in array_test)
        //    Debug.Log(array_test[value]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
