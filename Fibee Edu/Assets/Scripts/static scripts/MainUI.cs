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

    public void SetInfo(string txt)
    {
        txtInfo.text = txt;
    }

    public void SetClassNumberTextInButton(int classNr)
    {
        TextMeshProUGUI txtClassNumber = btnUserClass.GetComponentInChildren<TextMeshProUGUI>();
        txtClassNumber.text = classNr.ToString();
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
    }
 }
