using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class MainUI : MonoBehaviour
{
    public static MainUI instance;
    [SerializeField] Button btnBack, btnInfo, btnPoints, btnUserClass;
    [SerializeField] GameObject infoPanel;
    [SerializeField] Text txtInfo;
    [SerializeField] RawImage imgInfo;
    string info, imageUrl;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DisplayHideBtnInfo(bool b)
    {
        btnInfo.gameObject.SetActive(b);
    }
    public void ActivateBtnUser()
    {
        btnUserClass.interactable = true;
    }
    public void DisplayPoints()
    {
        btnPoints.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.instance.Points.ToString();
    }
    public void DisplayUserAndClass()
    {
        TextMeshProUGUI txtUserClass = btnUserClass.GetComponentInChildren<TextMeshProUGUI>();
        txtUserClass.text = GameManager.instance.Username;
        txtUserClass.text += " [" + GameManager.instance.ClassNumber + "]";
    }

    public void SetInfo(string txt)
    {
        info = txt;
    }

    public void SetImageUrl(string txt)
    {
        imageUrl = txt;
    }

    public IEnumerator SetImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            imgInfo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
    public void ShowInfoPanel(bool b)
    {
        infoPanel.SetActive(b);
        imgInfo.gameObject.SetActive(false);
        txtInfo.gameObject.SetActive(false);
        if (!System.String.IsNullOrEmpty(info))
        {
            txtInfo.gameObject.SetActive(true);
            txtInfo.text = info;
        }
        
        if(!System.String.IsNullOrEmpty(imageUrl))
        {
            imgInfo.gameObject.SetActive(true);
            StartCoroutine(SetImage(imageUrl));
        }
    }

    public void OpenAddTaskScene()
    {
        SceneChanger.instance.LoadScene(7);
    }
 }
