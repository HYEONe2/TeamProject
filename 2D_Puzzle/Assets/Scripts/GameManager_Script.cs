using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_Script : MonoBehaviour
{
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public GameObject particle_success;

    enum COLOR {COLOR_NORMAL, COLOR_BLUE, COLOR_RED, COLOR_END};

    private COLOR[,] colorArray = new COLOR[3, 3];
    private GameObject[,] gameObjectArray = new GameObject[3,3];

    float randomX;
    float randomY;

    //public Text scoreText;
    //public Text TimeText;

    public List<int> player_select = new List<int>();
    private int previouse_value=  0;

    public static bool CameraShaking_On = false;

    private string[] Object_Tag_Name = new string[] { "Block1", "Block2", "Block3" };

    // Start is called before the first frame update
    void Start()
    {
        Puzzle_Parameters.array[0, 0] = 0;
        Puzzle_Parameters.array[0, 1] = 0;
        Puzzle_Parameters.array[0, 2] = 0;

        Puzzle_Parameters.array[1, 0] = 1;
        Puzzle_Parameters.array[1, 1] = 1;
        Puzzle_Parameters.array[1, 2] = 1;

        Puzzle_Parameters.array[2, 0] = 2;
        Puzzle_Parameters.array[2, 1] = 2;
        Puzzle_Parameters.array[2, 2] = 2;

        GameObject pGameObject = null;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                float x_pos = i * 1.0f - 1.5f;
                float y_pos = j * 1.0f - 1.5f;

                if (Puzzle_Parameters.array[i, j] == 0)
                {
                    pGameObject = Instantiate(Block1, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }
                else if (Puzzle_Parameters.array[i, j] == 1)
                {
                    pGameObject = Instantiate(Block2, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }
                else if (Puzzle_Parameters.array[i, j] == 2)
                {
                    pGameObject = Instantiate(Block3, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }

                colorArray[i, j] = COLOR.COLOR_NORMAL;
                gameObjectArray[i, j] = pGameObject;
            }
        }
    }

    void Check_Block(Collider2D clickColl,int ArrNum)
    {
        GameObject pGameObject = null;
        GameObject pBlockObject = null;

        for (int i = 0; i < 3; ++i)
        {
            if (clickColl.gameObject == gameObjectArray[ArrNum, i])
            {
                Destroy(clickColl.gameObject);

                randomX = Random.Range(-9.35f, 9.35f);
                randomY = Random.Range(-4.7f, 4.7f);

                if (ArrNum == 0)
                    pBlockObject = Block1;
                else if (ArrNum == 1)
                    pBlockObject = Block2;
                else if (ArrNum == 2)
                    pBlockObject = Block3;

                if (colorArray[ArrNum, i] == COLOR.COLOR_NORMAL)
                {
                    pGameObject = Instantiate(pBlockObject, new Vector3(randomX, randomY, 0), Quaternion.identity);
                    pGameObject.transform.GetComponent<SpriteRenderer>().color = Color.blue;

                    colorArray[ArrNum, i] = COLOR.COLOR_BLUE;
                }
                else if (colorArray[ArrNum, i] == COLOR.COLOR_BLUE)
                {
                    pGameObject = Instantiate(pBlockObject, new Vector3(randomX, randomY, 0), Quaternion.identity);
                    pGameObject.transform.GetComponent<SpriteRenderer>().color = Color.red;

                    colorArray[ArrNum, i] = COLOR.COLOR_RED;
                    Puzzle_Parameters.score += (ArrNum + 1) * 2;
                }
                else if (colorArray[ArrNum, i] == COLOR.COLOR_RED)
                {
                    colorArray[ArrNum, i] = COLOR.COLOR_END;
                    Puzzle_Parameters.score += (ArrNum + 1) * 3;
                }

                gameObjectArray[ArrNum, i] = pGameObject;
            }
        }
    }

    void Time_Update()
    {
        if (Puzzle_Parameters.time >= 1)
        {
            Puzzle_Parameters.time -= 1;
            //TimeText.text = "Time: " + time.ToString();
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void Color_Update()
    {
        int iCnt = 0;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (colorArray[i, j] == COLOR.COLOR_END)
                    ++iCnt;
            }
        }
        if (iCnt == 9)
            SceneManager.LoadScene("SuccessScene");
    }

    void Score_Update()
    {
        Puzzle_Parameters.combo_counter = 0;
        for (int i = 0; i < player_select.Count; ++i)
        {
            //Debug.Log("player_select: " + i + " " + player_select[i]);

            if (previouse_value == player_select[i])
            {
                Puzzle_Parameters.combo_counter += 1;
            }

            previouse_value = player_select[i];
            //Debug.Log("combo_counter: " + combo_counter);
        }

        //foreach(int value in player_select)
        //{
        //    Debug.Log(value);
        //}
    }

    void Input_Update()
    {
        Collider2D clickColl = null;
        Vector3 worldPos = Vector3.zero;
        Vector2 clickPos = Vector2.zero;

        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickPos = new Vector2(worldPos.x, worldPos.y);
        clickColl = Physics2D.OverlapPoint(clickPos);

        if (Input.GetMouseButtonDown(0))
        {
            Block_Picking(clickColl, worldPos, clickPos);
        }
        else if(Input.GetMouseButton(1))
        {

        }
    }

    bool Tag_Compare(Collider2D clickColl, string[] Object_Tag_Name)
    {
        for(int i =0;i<Object_Tag_Name.Length; ++i)
        {
            if (clickColl.gameObject.tag == Object_Tag_Name[i])
            {
                Puzzle_Parameters.score += (i + 1);
                player_select.Add(i + 1);
                CameraShaking_On = true;
                Check_Block(clickColl, i);

                return true;
            }
        }

        return false;
    }

    void Block_Picking(Collider2D clickColl, Vector3 worldPos, Vector2 clickPos)
    {
        //RaycastHit2D hit = Physics2D.Raycast(worldPos, transform.forward, 100);
        //Debug.DrawRay(worldPos, transform.forward * 10, Color.red, 0.3f);

        //if(hit)
        //{
        //    //hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
        //    Instantiate(particle_success, new Vector2(clickPos.x, clickPos.y), Quaternion.identity);
        //}

        if (clickColl == null)
            return;

        Tag_Compare(clickColl, Object_Tag_Name);
        //if(Tag_Compare(clickColl, Object_Tag_Name) == true)
        //{
        //    //Puzzle_Parameters.score += (i + 1);
        //    //player_select.Add(i + 1);
        //    //CameraShaking_On = true;
        //    //Check_Block(clickColl, i);
        //}
    }

    void Print_Log()
    {
        Debug.Log("Best Score: " + Global_Game_Manager.Instance.best_score);
    }

    // Physx 사용 함수
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Time_Update();

        Color_Update();

        Score_Update();

        Input_Update();

        Print_Log();
    }
}
