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
    int allTasksQuantity, taskid;
    string [] tasksArray;
    string[] task;
    string answer;
    string solution;
    bool isRandomOn;
    string imageUrl;
    string url = "www.fibeesoft.com/projects/phicademia/db/texttask.php";

    private void Start()
    {
        
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
    public void GetTexture(string url)
    {
        
        StartCoroutine(GetTextureCoroutine(url));
    }

    private IEnumerator GetTextureCoroutine(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                print(unityWebRequest.error);
            }
            else
            {
                DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;

                imgTask.texture = downloadHandlerTexture.texture;
            }
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


    public void GenerateTask()
    {
        if (textTaskNumber < allTasksQuantity)
        {

            SetRandomOption();
            ChooseNextTaskNumber();
            task = tasksArray[textTaskNumber].Split('|');
            taskid = System.Convert.ToInt32(task[0]);
            txtTextTask.text = taskid + "\n" + task[1];
            answer = task[2];
            solution = task[4];
            imageUrl = task[5];
            string imageSolutionUrl = task[6];
            if(!System.String.IsNullOrEmpty(imageUrl))
            {
                imgTask.gameObject.SetActive(true);
                StartCoroutine(GetTextureCoroutine(imageUrl));
            }
            else
            {
                imgTask.gameObject.SetActive(false);
            }
            MainUI.instance.SetInfo(solution);
            if (!System.String.IsNullOrEmpty(imageSolutionUrl))
            {
                MainUI.instance.SetImage(imageSolutionUrl);
            }
        }
        else
        {
            txtTextTask.text = "You finished all the tasks. Well done!";
        }

    }



    public void Check()
    {
        if(inpAnswer.text.Trim().ToLower().Replace(" ", "").Replace(".",",") == answer)
        {
            inpAnswer.text = "";
            Animations.instance.AnimateCheckButton(true);
            GameManager.instance.AddPoints(2);
            if (!isRandomOn)
            {
                if(textTaskNumber < allTasksQuantity)
                {
                    NextTask();
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

    public void NextTask()
    {
        lastTaskNumber++;
        textTaskNumber = lastTaskNumber;
        GenerateTask();
    }   
    public void PrevTask()
    {
        lastTaskNumber--;
        textTaskNumber = lastTaskNumber;
        GenerateTask();
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
