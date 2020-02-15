using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject LoginPanel, RegisterPanel;
    [SerializeField] InputField inpLoginUsername, inpLoginPassword;
    [SerializeField] InputField inpRegUsername, inpRegPassword, inpRegEmail;
    [SerializeField] Slider sliderClass;

    private void Start()
    {
        SetInitialClassSlider();
        MainUI.instance.DisplayHideBtnInfo(false);
    }
 
    public void SetClassRoom()
    {
        GameManager.instance.ClassNumber = (int)sliderClass.value;
        MainUI.instance.DisplayUserAndClass();
    }
    void SetInitialClassSlider()
    {
        sliderClass.value = GameManager.instance.ClassNumber;
    }
    public void OpenLoginPanel(bool b)
    {
        ResetInputFields();
        LoginPanel.SetActive(b);
    }
    public void OpenRegisterPanel(bool b)
    {
        ResetInputFields();
        RegisterPanel.SetActive(b);
    }

    void ResetInputFields()
    {
        inpLoginUsername.text = "";
        inpLoginPassword.text = "";
        inpRegPassword.text = "";
        inpRegUsername.text = "";
        inpRegEmail.text = "";
    }

    public void Login()
    {
        StartCoroutine(LoginCor());
        OpenLoginPanel(false);
    }

    IEnumerator LoginCor()
    {
        string url = "www.pikademia.pl/apps/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", inpLoginUsername.text);
        form.AddField("password", inpLoginPassword.text);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.downloadHandler.text != "Fail")
                {
                    GameManager.instance.IsLoggedIn = true;
                    print(www.downloadHandler.text);
                    OpenLoginPanel(false);

                    string[] userInfo = www.downloadHandler.text.Split('|');

                    foreach (string p in userInfo)
                    {
                        print(p);
                    }
                    int points = System.Convert.ToInt32(userInfo[1]);
                    GameManager.instance.Points = points;
                    MainUI.instance.DisplayPoints();
                    GameManager.instance.Username = userInfo[0];
                    MainUI.instance.DisplayUserAndClass();
                    MainUI.instance.ActivateBtnUser();
                }
                else
                {
                    GameManager.instance.IsLoggedIn = false;
                    print(www.downloadHandler.text);
                    ResetInputFields();
                }
            }
        }
    }

    public void Register()
    {
        StartCoroutine(RegisterCor());
        OpenRegisterPanel(false);
    }
    IEnumerator RegisterCor()
    {

        string url = "www.pikademia.pl/apps/register.php";
        WWWForm form = new WWWForm();
        form.AddField("username", inpRegUsername.text);
        form.AddField("email", inpRegEmail.text);
        form.AddField("password", inpRegPassword.text);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if (www.downloadHandler.text == "Registered")
                {
                    print(www.downloadHandler.text);
                    OpenRegisterPanel(false);
                }
                else
                {
                    print(www.downloadHandler.text);
                }
            }
        }
    }

    public void StartTheGame()
    {
        SceneChanger.instance.LoadScene(1);
    }
}
