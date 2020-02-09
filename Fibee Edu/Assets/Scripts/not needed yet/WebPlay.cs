using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebPlay : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] InputField txtId, txtUsername;
    string url = "www.pikademia.pl/apps/index.php";
    string[] users;


    public void PullFromServer()
    {
        StartCoroutine(PullData());
    }
    IEnumerator PullData()
    {
        txt.text = "";

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
                users = fulldata.Split(';');
                foreach (var u in users)
                {
                    txt.text += u + "\n";
                }
            }
        }
    }

    public void PushToServer()
    {
        StartCoroutine(UploadToServer());
    }
    IEnumerator UploadToServer()
    {
        string url2 = "www.pikademia.pl/apps/update.php";
        string id = txtId.text;
        string username = txtUsername.text;
        WWWForm form = new WWWForm();
        form.AddField("_playerIdPost", id);
        form.AddField("_playerUsernamePost", username);

        using (UnityWebRequest www = UnityWebRequest.Post(url2, form))
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
