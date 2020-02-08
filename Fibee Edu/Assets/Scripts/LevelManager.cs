﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] Button btnBack;

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
    
    void Start()
    {
        
        btnBack.onClick.AddListener(delegate { StartCoroutine(LoadPreviousScene()); }) ;
        btnBack.GetComponent<Animator>().SetTrigger("animOn");
    }

    IEnumerator LoadPreviousScene()
    {

        btnBack.GetComponent<Animator>().SetTrigger("animOut");
        yield return new WaitForSeconds(0.3f);
        if(SceneManager.GetActiveScene().buildIndex == (int)Scenes.Game)
        {
            SceneChanger.instance.LoadScene((int)Scenes.MainMenu);
            btnBack.GetComponent<Animator>().SetTrigger("animOn");
        }
        else
        {
            SceneChanger.instance.LoadScene((int)Scenes.Game);
            btnBack.GetComponent<Animator>().SetTrigger("animOn");
        }
    }

    public void ActivateBackButton()
    {
        btnBack.GetComponent<Animator>().SetTrigger("animOn");
    }
    
    
}
