using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMesh_Script : MonoBehaviour
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
        resource = GameManager_Script.time;
        resourceText.text = "Time: " + resource.ToString();
    }
}
