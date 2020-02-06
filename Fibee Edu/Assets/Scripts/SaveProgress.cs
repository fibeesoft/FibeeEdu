using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public static SaveProgress instance;

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
    void Start()
    {
        if (PlayerPrefs.HasKey("PPpoints"))
        {
            GameManager.instance.Points = PlayerPrefs.GetInt("PPpoints");
        }
        else
        {
            GameManager.instance.Points = 0;
            
        }

        if (
            PlayerPrefs.HasKey("PPclassroom"))
        {
            GameManager.instance.SetClass(PlayerPrefs.GetInt("PPclassroom"));
        }
        else
        {
            GameManager.instance.SetClass(0);

        }
        SaveData();

    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PPpoints", GameManager.instance.Points);
        PlayerPrefs.SetInt("PPclassroom", GameManager.instance.GetClass());
    }

}
