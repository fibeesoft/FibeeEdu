using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public static MainUI instance;
    [SerializeField] Button btnBack, btnClassPick;
    [SerializeField] GameObject classPickContainer;
    [SerializeField] TextMeshProUGUI txtClass;
    int classSelected;

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
        btnClassPick.onClick.AddListener(delegate {
            StartCoroutine(ShowClassPickContainerCor());

        });
        btnBack.onClick.AddListener(delegate { StartCoroutine(LoadMainScene()); });
    }
    /// <summary>
    /// classPickContainer
    /// </summary>
    public void ShowClassPickContainer()
    {
        StartCoroutine(ShowClassPickContainerCor());
    }
    IEnumerator ShowClassPickContainerCor()
    {
        if (classPickContainer.activeSelf)
        {
            Animations.instance.AnimateClassPickContainer(false);
            yield return new WaitForSeconds(1.3f);
            classPickContainer.SetActive(false);
        }
        else
        {
            classPickContainer.SetActive(true);
            Animations.instance.AnimateClassPickContainer(true);
        }
    }


    public void SetClass(int c)
    {
        classSelected = c;
        txtClass.text = classSelected.ToString();
        //classRoomContainer.SetActive(false);
        SaveProgress.instance.SaveData();
    }
    public int GetClass()
    {
        return classSelected;
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

    public void DisplaySetClassContainer()
    {
        if (classPickContainer.activeSelf)
        {
            if (classSelected != 0)
            {
                classPickContainer.SetActive(false);
            }
            else
            {
                //prompt to choose classroom
            }

        }
        else
        {
            classPickContainer.SetActive(true);

        }
    }

}
