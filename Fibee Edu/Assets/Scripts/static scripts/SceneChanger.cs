using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    }

    public void LoadScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
    public void GoBack()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            LoadScene(0);
        }
        else
        {
            LoadScene(1);
        }
    }
}
