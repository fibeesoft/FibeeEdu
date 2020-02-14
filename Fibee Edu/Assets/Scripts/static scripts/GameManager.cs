using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI txtPoints, txtUsername;
    bool isLoggedIn = false;
    public bool IsLoggedIn { get { return isLoggedIn; } set { isLoggedIn = value; } }
    int points;
    public int Points { get { return points; } set { points = value; DisplayPoints(); } }
    string username;
    public string Username { get { return username; } set { username = value; DisplayUsername(); } }
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

    void Start()
    {
      
        DisplayPoints(); 
    }

    void DisplayPoints()
    {
        txtPoints.text = "POINTS: " + Points.ToString();
    }
    void DisplayUsername()
    {
        txtUsername.text = Username;
    }

    public void AddPoints(int point)
    {
        Points += point;
        print(Points);
        DisplayPoints();
        if (isLoggedIn)
        {
            UpdatePoints();
        }
    }
    public void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCor());
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
