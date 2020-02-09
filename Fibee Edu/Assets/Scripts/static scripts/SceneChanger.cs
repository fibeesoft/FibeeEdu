using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    MainMenu,
    Game,
    Clock,
    MultiplicationTable,
    MathTextTask,
    webPlay
}

public enum Tasks
{
    NoTask,
    Clock,
    MultiplicationTable,
    MathTextTask
}

public enum Language
{
    English,
    Polish
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
