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
    [SerializeField] Slider sliderRandOption;
    [SerializeField] RawImage imgTask;
    int textTaskNumber = 0, lastTaskNumber = 0;
    int allTasksQuantity;
    string [] tasksArray;
    string[] task;
    string answer;
    string solution;
    bool isRandomOn;
    string imageUrl;
    string url = "www.fibeesoft.com/projects/phicademia/db/texttask.php";

    private void Start()
    {
        MainUI.instance.SetExplanation("Solve text tasks and provide clear answer in the input box. All answers should be provided as pure numbers or single word.");
        int classNumber = GameManager.instance.ClassNumber;
        StartCoroutine(GetTextTasks(classNumber));
        textTaskNumber = lastTaskNumber;
        
    }
    IEnumerator GetTextTasks(int classNumber)
    {
        WWWForm form = new WWWForm();
        form.AddField("classNumber", classNumber);
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url,form))
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
            SetRandomOption();
            ChooseNextTaskNumber();
            task = tasksArray[textTaskNumber].Split('|');
            txtTextTask.text = task[0];
            answer = task[1];
            solution = task[3];
            imageUrl = task[4];
            string imageSolutionUrl = task[5];
            if(imageUrl.Length > 1)
            {
                imgTask.gameObject.SetActive(true);
                StartCoroutine(SetImage(imageUrl));
            }
            else
            {
                imgTask.gameObject.SetActive(false);
            }
            MainUI.instance.SetSolution(solution, imageSolutionUrl);
            print(answer);

        }
        else
        {
            txtTextTask.text = "You finished all the tasks. Well done!";
        }

    }

    IEnumerator SetImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            imgTask.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    public void Check()
    {
        if(inpAnswer.text == answer)
        {
            inpAnswer.text = "";
            Animations.instance.AnimateCheckButton(true);
            GameManager.instance.AddPoints(2);
            if (!isRandomOn)
            {
                if(textTaskNumber < allTasksQuantity)
                {
                    lastTaskNumber++;
                    textTaskNumber = lastTaskNumber;
                    GenerateTask();
                }
                else
                {
                    txtTextTask.text = "Pula zadań została wyczerpana. Gratulacje :)";
                }
            }
            else
            {
                GenerateTask();

            }

        }
        else
        {
            Animations.instance.AnimateCheckButton(false);
            inpAnswer.text = "";
        }
    }

    public void SetRandomOption()
    {
        if(sliderRandOption.value == 0)
        {
            isRandomOn = false;
        }
        else
        {
            isRandomOn = true;
        }
    }
    void ChooseNextTaskNumber()
    {
        if (isRandomOn)
        {
            textTaskNumber = Random.Range(0, allTasksQuantity);
        }
        else
        {
            textTaskNumber = lastTaskNumber;
        }
    }
}
