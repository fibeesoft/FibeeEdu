using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainUI : MonoBehaviour
{
    public static MainUI instance;
    [SerializeField] Button btnBack, btnSolution, btnExplanation, btnUser;
    [SerializeField] GameObject solutionPanel, infoPanel;
    [SerializeField] Text txtSolution, txtExplanation;
    [SerializeField] RawImage imgSolution;
    [SerializeField] TextMeshProUGUI txtClassNumber;
    string solutionText, explanationText, imageSolutionUrl;
    public void SetSolution(string txt, string imgUrl)
    {
        solutionText = txt;
        txtSolution.text = txt;
        imageSolutionUrl = imgUrl;

    }
    public void SetSolution(string txt)
    {
        solutionText = txt;
        txtSolution.text = txt;
    }

    public void SetClassNumberText(int classNr)
    {
        txtClassNumber.text = classNr.ToString();
    }
    IEnumerator SetImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            imgSolution.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    public void SetExplanation(string txt)
    {
        explanationText = txt;
        txtExplanation.text = txt;
    }

    public void ActivateUserButton(bool b)
    {
        btnUser.interactable = b;
    }
    public void ActivateTaskSpecificButtons(bool b)
    {
        if (b)
        {
            btnSolution.interactable = true;
            btnExplanation.interactable = true;
        }
        else
        {
            btnSolution.interactable = false;
            btnExplanation.interactable = false;
        }
    }


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
    void Start()
    {

        btnBack.onClick.AddListener(delegate { StartCoroutine(LoadMainScene()); });
    }

    public void ShowInfoPanel(bool b)
    {
        infoPanel.SetActive(b);
    }

    public void ShowSolutionContainer(string txt)
    {
        if(imageSolutionUrl != "")
        {
            StartCoroutine(SetImage(imageSolutionUrl));
        }
        if (GameObject.FindObjectOfType<TaskManager>())
        {
            StartCoroutine(ShowSolutionContainerCor(txt));

        }
    }
    IEnumerator ShowSolutionContainerCor(string txt)
    {

        if (solutionPanel.activeSelf)
        {

            yield return new WaitForSeconds(0.3f);
            solutionPanel.SetActive(false);
        }
        else
        {
            solutionPanel.SetActive(true);
        }
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(0.3f);
        if (SceneManager.GetActiveScene().buildIndex == (int)Scenes.Game)
        {
            SceneChanger.instance.LoadScene((int)Scenes.MainMenu);
        }
        else
        {
            SceneChanger.instance.LoadScene((int)Scenes.Game);
        }
    }

 }
