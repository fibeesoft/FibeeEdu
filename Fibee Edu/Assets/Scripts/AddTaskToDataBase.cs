﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AddTaskToDataBase : MonoBehaviour
{
    [SerializeField] InputField inpQuestion;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Dropdown dropClass;
    [SerializeField] Dropdown dropCategory;

    public void PushToServer()
    {
        StartCoroutine(UploadToServer());
    }

    IEnumerator UploadToServer()
    {
        string url = "www.pikademia.pl/apps/insert_task.php";
        string question = inpQuestion.text;
        string answer = inpAnswer.text;
        string classPick = dropClass.value.ToString();
        string category = dropCategory.value.ToString();
        WWWForm form = new WWWForm();
        form.AddField("_questionPost", question);
        form.AddField("_answerPost", answer);
        form.AddField("_classPickPost", classPick);
        form.AddField("_category", category);

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
            }
        }
    }
}
