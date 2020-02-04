using System.Collections;
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
    }

    IEnumerator LoadPreviousScene()
    {
        GameObject.FindObjectOfType<DissolveController>().DissolveButton();
        yield return new WaitForSeconds(1);
        if(SceneManager.GetActiveScene().buildIndex == (int)Scenes.Game)
        {
            SceneChanger.instance.LoadScene((int)Scenes.MainMenu);
        }
        else
        {
            SceneChanger.instance.LoadScene((int)Scenes.Game);
        }
        GameObject.FindObjectOfType<DissolveController>().ShowButton();
    }

    
}
