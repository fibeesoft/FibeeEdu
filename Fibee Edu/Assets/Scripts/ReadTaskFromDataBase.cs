using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReadTaskFromDataBase : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] Dropdown dropID;
    string url = "www.pikademia.pl/apps/selectparameter.php";
    string[] tasks;

    string id;
    public void PullFromServer()
    {
        StartCoroutine(PullData());
    }



 

    
    IEnumerator PullData()
    {
        WWWForm form = new WWWForm();
        form.AddField("_id", id);
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
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                string fulldata = webRequest.downloadHandler.text;
                tasks = fulldata.Split('|');
                foreach (var t in tasks)
                {     
                    txt.text += t + "\n"; 
                }
            }
        }
    }

}
