using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI txtPoints;
    [SerializeField] TextMeshProUGUI txtClass;

    int points;
    public int Points { get { return points; } set { points = value; DisplayPoints(); } }

    public Tasks CurrentTask { get; set; }
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

    private void Update()
    {
      
    }
    void DisplayPoints()
    {
        txtPoints.text = "POINTS: " + Points.ToString();
    }

    public void AddPoints(int point)
    {
        Points += point;
        DisplayPoints();
        SaveProgress.instance.SaveData();
    }








    public void SwitchTask(Tasks t)
    {
        CurrentTask = t;
        TasksExplanation.instance.ActivateTaskExplanationButton();
    }




}
