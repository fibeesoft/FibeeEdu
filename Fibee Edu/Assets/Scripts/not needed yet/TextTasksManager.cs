using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextTasksManager : MonoBehaviour
{
    [SerializeField] Text txtTask;
    [SerializeField] Button btnCheck;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Text txtTaskNumber;
    string goodAnswer, solution;
    int textTaskNumber = 33;
     void Start()
    {
        GenerateTextTask();
    }


    public void GenerateTextTask()
    {

        
        inpAnswer.text = "";
        inpAnswer.ActivateInputField();
        PullFromServer();
    }

    public void Check()
    {
        if(inpAnswer.text.ToLower().Trim() == goodAnswer)
        {
           
            GameManager.instance.AddPoints(1);
           
        }
        else
        {
            
            inpAnswer.text = "";
            inpAnswer.ActivateInputField();
        }
    }


    string url = "www.pikademia.pl/apps/selectparameter.php";
    string[] tasks;
    public void PullFromServer()
    {
        StartCoroutine(PullData());
    }

    IEnumerator PullData()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", textTaskNumber);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);

                string fulldata = www.downloadHandler.text;
                tasks = fulldata.Split('|');
                txtTaskNumber.text = tasks[0];
                txtTask.text = tasks[1];
                goodAnswer = tasks[2];
                solution = tasks[3];
            }
        }
    }

}
