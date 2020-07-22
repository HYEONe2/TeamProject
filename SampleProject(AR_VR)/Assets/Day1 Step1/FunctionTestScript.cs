using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTestScript : MonoBehaviour
{
    bool bIsInCube = false;
    bool bIsClicked = false;
    bool bCheckOnce = false;
    int iCount = 0;

    //int Score = 85;

    // Start is called before the first frame update
    void Start()
    {
        int result1, result2;
        result1 = Sum(10, 20);
        result2 = Sum(30, 40);

        //print("Result 1: " + result1);
        //print("Result 2: " + result2);

        //if (Score >= 90)
        //{
        //    print("90점 이상입니다.");
        //}
        //else if (Score >= 80)
        //{
        //    print("80점 이상입니다.");
        //}
        //else
        //{
        //    print("80점 미만입니다.");
        //}
    }

    int Sum(int num1, int num2)
    {
        return num1 + num2;
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsClicked && bIsInCube)
        {
            if (!bCheckOnce)
            {
                ++iCount;
                bCheckOnce = true;
            }
        }
    }

    private void OnMouseEnter()
    {
        //print("마우스 ENTER");
        bIsInCube = true;
    }

    private void OnMouseExit()
    {
        //print("마우스 EXIT");
        bIsInCube = false;
    }

    private void OnMouseDown()
    {
        //print("마우스 눌림");
        bIsClicked = true;
    }

    private void OnMouseUp()
    {
        //print("마우스 뗌");
        bIsClicked = false;
        bCheckOnce = false;
    }
}
