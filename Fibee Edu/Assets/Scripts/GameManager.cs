using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI txtPoints;
    int points = 0;
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
        txtPoints.text = "POINTS: " + points.ToString();
    }


    public void AddPoints(int point)
    {
        points += point;
        DisplayPoints();
    }
}
