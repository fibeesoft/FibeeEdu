using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextTask : MonoBehaviour
{
    //get all SQL records as json file based on class picked on Start()
    //create array out of json objects on Start()
    //
    [SerializeField] Text txtTextTask;
    [SerializeField] InputField inpAnswer;
    int textTaskNumber = 0;
    int allTasksQuantity;
    string [] tasksArray;
    string[] task;
    string answer;
    string solution;
    string url = "www.fibeesoft.com/projects/phicademia/db/texttask.php";

    private void Start()
    {
        StartCoroutine(GetTextTasks());
        
    }
    IEnumerator GetTextTasks()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log("Received: " + webRequest.downloadHandler.text);
                string fulldata = webRequest.downloadHandler.text;
                tasksArray = fulldata.Split(';');
                allTasksQuantity = tasksArray.Length - 1;
                print(allTasksQuantity);
                foreach(var i in tasksArray)
                {
                    print(i);
                }
                GenerateTask();
            }
        }
    }

    public void GenerateTask()
    {
        if (textTaskNumber < allTasksQuantity)
        {
            task = tasksArray[textTaskNumber].Split('|');
            txtTextTask.text = task[0];
            answer = task[1];
            solution = task[3];
            MainUI.instance.SetSolution(solution);
            print(answer);
        }
        else
        {
            txtTextTask.text = "You finished all the tasks. Well done!";
        }

    }

    public void Check()
    {
        if(inpAnswer.text == answer)
        {
            inpAnswer.text = "";
            Animations.instance.AnimateCheckButton(true);
            GameManager.instance.AddPoints(2);
            textTaskNumber++;
            GenerateTask();
        }
        else
        {
            Animations.instance.AnimateCheckButton(false);
            inpAnswer.text = "";
        }

    }
}
