using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTasksManager : MonoBehaviour
{
    [SerializeField] Text txtTask;
    [SerializeField] Button btnCheck;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Text txtTaskNumber;

    public List<TextTasks> tasksList;
    public int textTaskNumber = 0;
     void Start()
    {
        CreateTasksList();
        GenerateTextTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTasksList()
    {
        tasksList.Add(new TextTasks(0, "Jakiego koloru jest biały maluch?", "biały"));
        tasksList.Add(new TextTasks(1, "Jakiego koloru jest zielony maluch?", "zielony"));
    }

    void NextTask()
    {
        if(textTaskNumber < tasksList.Count - 1)
        {
            textTaskNumber++;
        }
        else
        {
            textTaskNumber = 0;
        }
        GenerateTextTask();
    }

    public void GenerateTextTask()
    {

        txtTask.text = tasksList[textTaskNumber].taskQuestion;
        txtTaskNumber.text = tasksList[textTaskNumber].id.ToString();
        inpAnswer.text = "";
        inpAnswer.ActivateInputField();
    }

    public void Check()
    {
        if(inpAnswer.text.ToLower().Trim() == tasksList[textTaskNumber].taskGoodAnswer)
        {
            GameManager.instance.DisplayResultMessage(true);
            GameManager.instance.AddPoints(1);
            NextTask();
        }
        else
        {
            GameManager.instance.DisplayResultMessage(false);
            inpAnswer.text = "";
            inpAnswer.ActivateInputField();
        }
    }

}
