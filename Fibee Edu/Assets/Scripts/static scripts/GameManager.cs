using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool isLoggedIn = false;
    public bool IsLoggedIn { get { return isLoggedIn; } set { isLoggedIn = value; } }
    int points;
    public int Points { get { return points; } set { points = value; } }
    string username;
    public string Username { get { return username; } set { username = value; } }
    int classNumber;
    public int ClassNumber { get { return classNumber; } set { classNumber = value; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddPoints(int point)
    {
        Points += point;
        MainUI.instance.DisplayPoints();
        if (isLoggedIn)
        {
            StartCoroutine(UpdatePointsCor());
        }
    }

    

    IEnumerator UpdatePointsCor()
    {
        string url = "www.pikademia.pl/apps/updatePoints.php";
        WWWForm form = new WWWForm();
        form.AddField("username", Username);
        form.AddField("points", Points);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                print(www.downloadHandler.text);
            }
        }
    }
}
