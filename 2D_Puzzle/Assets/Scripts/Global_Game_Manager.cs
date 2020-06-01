using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Game_Manager : MonoBehaviour
{
    public int best_score = 10;
    public static Global_Game_Manager Instance;

    public int level;

    void Awake()
    {
        Instance = this;
    }

    //private Global_Game_Manager()
    //{
    //}
    
    //public static Global_Game_Manager Instance
    //{
    //    get
    //    {
    //        if(Instance == null)
    //        {
    //            Instance = new Global_Game_Manager();
    //        }
    //        return Instance;
    //    }
    
    //    private set
    //    {
    //        Instance = value;
    //    }
    //}

    // 예외 처리 코드

    // 멀티 쓰레드
}
