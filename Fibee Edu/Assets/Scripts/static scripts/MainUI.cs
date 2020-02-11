using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public static MainUI instance;
    [SerializeField] Button btnBack, btnSolution, btnExplanation, btnUser;
    [SerializeField] GameObject solutionPanel, explanationPanel;
    [SerializeField] Text txtSolution, txtExplanation;
    string solutionText, explanationText;
    public void SetSolution(string txt)
    {
        solutionText = txt;
        txtSolution.text = txt;
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


    public void ShowSolutionContainer(string txt)
    {
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
