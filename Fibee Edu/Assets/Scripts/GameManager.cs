using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI txtPoints;
    [SerializeField] TextMeshProUGUI txtClass, txtResultMessage;
    [SerializeField] GameObject classRoomContainer;
    [SerializeField] Button btnClassRoom;

    public int Points { get; set;}
    int classSelected;
    public Tasks CurrentTask { get; set; }
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
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
        DisplayPoints();
        btnClassRoom.onClick.AddListener(delegate {
            DisplaySetClassContainer();
        
        });
        
    }

    private void Update()
    {
      
    }
    void DisplayPoints()
    {
        txtPoints.text = "POINTS: " + Points.ToString();
    }

    public void AddPoints(int point)
    {
        Points += point;
        DisplayPoints();
        SaveProgress.instance.SaveData();
    }


    public void SetClass(int c)
    {
        classSelected = c;
        txtClass.text = classSelected.ToString();
        classRoomContainer.SetActive(false);
        SaveProgress.instance.SaveData();
    }

    public int GetClass()
    {
        return classSelected;
    }

    public void DisplaySetClassContainer()
    {
        if (classRoomContainer.activeSelf)
        {
            if(classSelected != 0)
            {
                classRoomContainer.SetActive(false);
            }
            else
            {
                //prompt to choose classroom
            }

        }
        else
        {
            classRoomContainer.SetActive(true);
        }
    }

    public void SwitchTask(Tasks t)
    {
        CurrentTask = t;
        TasksExplanation.instance.ActivateTaskExplanationButton();
    }

    public void DisplayResultMessage(bool b)
    {
        txtResultMessage.gameObject.SetActive(true);
        if (b)
        {
            txtResultMessage.text = "WELL DONE!";
            txtResultMessage.color = Color.green;
        }
        else
        {
            txtResultMessage.text = "TRY AGAIN!";
            txtResultMessage.color = Color.red;
        }
        StartCoroutine(AfterCheck());
    }
    IEnumerator AfterCheck()
    {
        yield return new WaitForSeconds(1f);
        txtResultMessage.gameObject.SetActive(false);
    }

    public void ActivateCheckButton(bool isAnswerCorrect)
    {
        GameObject checkButtonAnim;
        checkButtonAnim = GameObject.FindGameObjectWithTag("CheckButton");
        if (checkButtonAnim != null)
        {
            if (isAnswerCorrect)
            {
                checkButtonAnim.GetComponent<Animator>().SetTrigger("buttonGoodAnswer");
            }
            else
            {
                checkButtonAnim.GetComponent<Animator>().SetTrigger("buttonBadAnswer");
            }
        }
    }

}
