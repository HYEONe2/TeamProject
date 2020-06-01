using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMeshScore_Script : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    private int resource;

    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        resource = Puzzle_Parameters.score;
        resourceText.text = "Score: " + resource.ToString();
    }
}
