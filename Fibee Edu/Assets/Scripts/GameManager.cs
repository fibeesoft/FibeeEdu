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
    [SerializeField] GameObject ClassRoomContainer;
    [SerializeField] Button btnClassRoom;
    int points = 0;
    int classSelected;
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
        btnClassRoom.onClick.AddListener(delegate {
            DisplaySetClassContainer();
        
        });
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

    public void SetClass(int c)
    {
        classSelected = c;
        txtClass.text = "CLASSROOM: " + classSelected;
        ClassRoomContainer.SetActive(false);
    }

    public int GetClass()
    {
        return classSelected;
    }

    public void DisplaySetClassContainer()
    {
        ClassRoomContainer.SetActive(true);
    }
}
