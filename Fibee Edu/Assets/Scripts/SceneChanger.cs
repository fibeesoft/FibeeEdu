using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    MainMenu,
    Game,
    ClockTower,
    ClockTowerSetTime,
    ClockTowerReadTime,
    PitagorasHouse,
    webPlay
}

public enum Tasks
{
    ClockTowerSetTime,
    ClockTowerReadTime,
    MultiplicationTable

}

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
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
        //DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene((int)Scenes.Game);
        }
    }
    public void LoadScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }

    public void LoadWWW()
    {
        LoadScene((int)Scenes.webPlay);
    }
}
