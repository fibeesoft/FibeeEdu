using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTowerManager : MonoBehaviour
{

    public void ReadTime()
    {
        SceneChanger.instance.LoadScene((int)Scenes.ClockTowerReadTime);
    }
    public void SetTime()
    {
        SceneChanger.instance.LoadScene((int)Scenes.ClockTowerSetTime);
    }






    
}
