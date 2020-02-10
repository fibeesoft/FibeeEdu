using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserManager : MonoBehaviour
{
    public static UserManager instance;
    [SerializeField] GameObject LoginPanel,RegisterPanel;
    [SerializeField] InputField inpLoginUsername, inpLoginPassword;
    [SerializeField] InputField inpRegUsername, inpRegPassword, inpRegEmail;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    bool isLoggedIn = false;
    public bool IsLoggedIn { get { return isLoggedIn; } }

    string username;

    private void Start()
    {
        LoginPanel.SetActive(false);
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
    }

    IEnumerator LoginCor()
    {
        username = inpLoginUsername.text;
        string url = "www.pikademia.pl/apps/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", inpLoginPassword.text);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                if(www.downloadHandler.text == "Log")
                {
                    isLoggedIn = true;
                    print(www.downloadHandler.text);
                    OpenLoginPanel(false);
                    MainUI.instance.ActivateUserButton(true);
                }
                else
                {
                    isLoggedIn = false;
                    MainUI.instance.ActivateUserButton(false);
                    print(www.downloadHandler.text);
                    ResetInputFields();
                }
            }
        }
    }


    public void Register()
    {
        StartCoroutine(RegisterCor());
    }
    IEnumerator RegisterCor(){
        
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
}
