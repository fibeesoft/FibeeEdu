using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ReadTaskFromDataBase : MonoBehaviour
{
    [SerializeField] Dropdown dropID;
    string url = "www.pikademia.pl/apps/selectparameter.php";
    string[] tasks;
    public void PullFromServer()
    {
        StartCoroutine(PullData());
    }

    IEnumerator PullData()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", dropID.value);
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
                
                    //string fulldata = webRequest.downloadHandler.text;
                    //tasks = fulldata.Split('|');
                    //foreach (var t in tasks)
                    //{
                        //   txt.text += t + "\n";
                    //}
            }
        }
    }

}
