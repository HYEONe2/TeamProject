using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class LogIn_UIManager : MonoBehaviour
{
    enum ERROR_MSG { ID_BLANK_ERROR, PASSWORD_BLANK_ERROR, ID_EXIST_ERROR, ID_ERROR, PASSWORD_ERROR, ERROR_END };

    struct UserInfo
    {
        public string strID;
        public string strPassword;
    };
    private List<UserInfo> UserInfoList;

    [SerializeField] private InputField ID;
    [SerializeField] private InputField Password;

    [SerializeField] private GameObject LogInErrorPanel;
    [SerializeField] private GameObject ErrorText;

    // Start is called before the first frame update
    void Start()
    {
        UserInfoList = new List<UserInfo>();

        LogInErrorPanel.SetActive(false);
        ErrorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickEnd_SignInButton()
    {
        UserInfo Info;

        if (ID.text == "")
        {
            LogInError_PopUpUI(ERROR_MSG.ID_BLANK_ERROR);
            return;
        }
        foreach (UserInfo tempInfo in UserInfoList)
        {
            if (tempInfo.strID == ID.text)
            {
                LogInError_PopUpUI(ERROR_MSG.ID_EXIST_ERROR);
                return;
            }
            else
                continue;
        }
        Info.strID = ID.text;

        if (Password.text == "")
        {
            LogInError_PopUpUI(ERROR_MSG.PASSWORD_BLANK_ERROR);
            return;
        }
        Info.strPassword = Password.text;

        UserInfoList.Add(Info);
    }

    public void ClickEnd_LogInButton()
    {
        foreach(UserInfo tempInfo in UserInfoList)
        {
            if (tempInfo.strID != ID.text)
            {
                continue;
            }
            else
            {
                if (tempInfo.strPassword == Password.text)
                {
                    SceneManager.LoadScene("MainScene");
                    return;
                }
                else
                {
                    LogInError_PopUpUI(ERROR_MSG.PASSWORD_ERROR);
                    return;
                }
            }
        }

        LogInError_PopUpUI(ERROR_MSG.ID_ERROR);
    }

    public void ClickEnd_ExitButton()
    {
        Application.Quit();
        Debug.Log("ExitButton Clicked");
    }

    void LogInError_PopUpUI(ERROR_MSG eMsg)
    {
        LogInErrorPanel.SetActive(true);
        ErrorText.SetActive(true);

        switch (eMsg)
        {
            case ERROR_MSG.ID_BLANK_ERROR:
                ErrorText.GetComponent<TextMeshProUGUI>().text = "The ID is blank.";
                break;
            case ERROR_MSG.PASSWORD_BLANK_ERROR:
                ErrorText.GetComponent<TextMeshProUGUI>().text = "The PASSWORD is blank.";
                break;
            case ERROR_MSG.ID_EXIST_ERROR:
                ErrorText.GetComponent<TextMeshProUGUI>().text = "The ID already exists.";
                break;
            case ERROR_MSG.ID_ERROR:
                ErrorText.GetComponent<TextMeshProUGUI>().text = "The ID does NOT exists.";
                break;
            case ERROR_MSG.PASSWORD_ERROR:
                ErrorText.GetComponent<TextMeshProUGUI>().text = "The PASSWORD is incorrect.";
                break;
        }
    }

    public void ClickEnd_CloseButton()
    {
        LogInErrorPanel.SetActive(false);
        ErrorText.SetActive(false);
    }
}
