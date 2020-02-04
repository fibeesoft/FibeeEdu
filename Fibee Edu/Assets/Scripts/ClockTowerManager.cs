using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTowerManager : MonoBehaviour
{
    [SerializeField] GameObject minutePointer;
    [SerializeField] GameObject hourPointer;
    [SerializeField] TextMeshProUGUI txtTime, txtTask1Result;
    [SerializeField] Slider slider12_24Switch;
    int minutes, hours;
    int generatedMinute, generatedHour;
    int gameState;
    void Start()
    {
        txtTask1Result.enabled = false;
        gameState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == 1)
        {

        }    
    }


    public void GetMinutes(int minutes)
    {
        this.minutes = minutes;
    }

    public void GetHours(int hours)
    {
        this.hours = hours;
    }

    public void GenerateTime()
    {
        int maxValue = 12;
        if(slider12_24Switch.value == 0)
        {
            maxValue = 12;
        }
        else
        {
            maxValue = 24;
        }
        generatedHour = Random.Range(0, maxValue);
        generatedMinute = Random.Range(0, 60);
        txtTime.text = generatedHour.ToString("00") + " : " + generatedMinute.ToString("00");
    }

    public void Check()
    {
        StartCoroutine(DisplayTaskResultMessage());
        if((generatedHour == hours || generatedHour == hours + 12 ) && generatedMinute == minutes)
        {
            txtTask1Result.text = "WELL DONE!";
            GameManager.instance.AddPoints(1);
            GenerateTime();
            hourPointer.GetComponent<HourPointer>().ResetTime();
            minutePointer.GetComponent<MinutePointer>().ResetTime();
        }
        else
        {
            txtTask1Result.text = "TRY AGAIN!";
            
        }
    }

    IEnumerator DisplayTaskResultMessage()
    {
        txtTask1Result.enabled = true;
        yield return new WaitForSeconds(1f);
        txtTask1Result.enabled = false;
    }
    
}
