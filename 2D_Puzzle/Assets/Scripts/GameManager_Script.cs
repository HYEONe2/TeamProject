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

    public int[,] array = new int[3, 3];

    public static int score = 0;
    //public Text scoreText;

    public static int time = 600;
    //public Text TimeText;

    public List<int> player_select = new List<int>();
    private int previouse_value=  0;
    private int combo_counter = 0;

    public static bool CameraShaking_On = false;

    // Start is called before the first frame update
    void Start()
    {
        array[0, 0] = 0;
        array[0, 1] = 0;
        array[0, 2] = 0;

        array[1, 0] = 1;
        array[1, 1] = 1;
        array[1, 2] = 1;

        array[2, 0] = 2;
        array[2, 1] = 2;
        array[2, 2] = 2;

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                float x_pos = i * 1.0f - 1.5f;
                float y_pos = j * 1.0f - 1.5f;

                if (array[i, j] == 0)
                {
                    Instantiate(Block1, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }
                else if (array[i, j] == 1)
                {
                    Instantiate(Block2, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }
                else if (array[i, j] == 2)
                {
                    Instantiate(Block3, new Vector3(x_pos, y_pos, 0), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D clickColl = null;
        Vector3 worldPos;
        Vector2 clickPos;

        if (time >= 1)
        {
            time -= 1;
            //TimeText.text = "Time: " + time.ToString();
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }

        if (score > 10)
            SceneManager.LoadScene("SuccessScene");

        if (Input.GetMouseButtonDown(0))
        {
            worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos = new Vector2(worldPos.x, worldPos.y);
            clickColl = Physics2D.OverlapPoint(clickPos);

            RaycastHit2D hit = Physics2D.Raycast(worldPos, transform.forward, 100);
            Debug.DrawRay(worldPos, transform.forward * 10, Color.red, 0.3f);

            if(hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
                Instantiate(particle_success, new Vector2(clickPos.x, clickPos.y), Quaternion.identity);
            }

            if (clickColl.gameObject.tag == "Block1")
            {
                score += 1;
                //scoreText.text = "Score: " + score.ToString();
                player_select.Add(1);
                Destroy(clickColl.gameObject);
                CameraShaking_On = true;


            }
            if (clickColl.gameObject.tag == "Block2")
            {
                score += 2;
                //scoreText.text = "Score: " + score.ToString();
                player_select.Add(2);
                Destroy(clickColl.gameObject);
                CameraShaking_On = true;
            }
            if (clickColl.gameObject.tag == "Block3")
            {
                score += 3;
                //scoreText.text = "Score: " + score.ToString();
                player_select.Add(3);
                Destroy(clickColl.gameObject);
                CameraShaking_On = true;
            }
        }

        combo_counter = 0;
        for (int i=0;i<player_select.Count; ++i)
        {
            Debug.Log("player_select: " + i +" " + player_select[i]);

            if(previouse_value== player_select[i])
            {
                combo_counter += 1;
            }

            previouse_value = player_select[i];
            Debug.Log("combo_counter: " + combo_counter);
        }

        //foreach(int value in player_select)
        //{
        //    Debug.Log(value);
        //}
    }
}
