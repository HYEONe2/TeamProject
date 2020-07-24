using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject LogoButton;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickEnd_SettingButton()
    {
        SettingPanel.SetActive(true);
    }

    public void ClickEnd_CloseButton()
    {
        SettingPanel.SetActive(false);
    } 

    public void ClickEnd_LogoButton()
    {
        SceneManager.LoadScene("LogIn");
        Debug.Log("DLKFJSLEKF");
        return;
    }
}
