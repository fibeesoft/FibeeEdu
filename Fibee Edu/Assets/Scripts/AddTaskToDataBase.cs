using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AddTaskToDataBase : MonoBehaviour
{
    [SerializeField] InputField inpQuestion;
    [SerializeField] InputField inpAnswer;
    [SerializeField] InputField inpSolution;
    [SerializeField] Dropdown dropClass;

    public void PushToServer()
    {
        StartCoroutine(UploadToServer());
    }

    IEnumerator UploadToServer()
    {
        string url = "www.fibeesoft.com/projects/phicademia/db/addtexttask.php";
        string question = inpQuestion.text;
        string answer = inpAnswer.text;
        string classPick = dropClass.value.ToString();
        string solution = inpSolution.text;
        WWWForm form = new WWWForm();
        form.AddField("question", question);
        form.AddField("answer", answer);
        form.AddField("class", classPick);
        form.AddField("solution", solution);

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
            }
        }

        inpAnswer.text = "";
        inpQuestion.text = "";
        inpSolution.text = "";
        dropClass.value = 0;
    }
}
