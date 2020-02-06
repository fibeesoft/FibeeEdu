using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTower_MoveClockPointers : MonoBehaviour
{
    [SerializeField] GameObject minutePointer;
    [SerializeField] GameObject hourPointer;
    [SerializeField] TextMeshProUGUI txtTime, txtTask1Result;
    [SerializeField] Slider slider12_24Switch;
    int minutes, hours;
    int maxValue;
    float tempMinutes, tempHours;
    int generatedMinute, generatedHour;
    float speed = 80f;

    void Start()
    {
        GameManager.instance.SwitchTask(Tasks.ClockTowerSetTime);
        txtTask1Result.enabled = false;
        GenerateTime();
    }

    private void Update()
    {
        if(tempHours < generatedHour)
        {
            tempHours += Time.deltaTime * speed + generatedHour * Time.deltaTime;
            txtTime.text = tempHours.ToString("00") + " : " + tempMinutes.ToString("00");
        }
        if(tempMinutes < generatedMinute)
        {
            tempMinutes += Time.deltaTime * speed + generatedMinute * Time.deltaTime;
            txtTime.text = tempHours.ToString("00") + " : " + tempMinutes.ToString("00");
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
        tempMinutes = 0;
        tempHours = 0;
        maxValue = 12;
        if (slider12_24Switch.value == 0)
        {
            maxValue = 12;
        }
        else
        {
            maxValue = 24;
        }
        generatedHour = Random.Range(0, maxValue);
        generatedMinute = Random.Range(0, 60);
    }

    public void Check()
    {
        StartCoroutine(DisplayTaskResultMessage());
        if ((generatedHour == hours || generatedHour == hours + 12) && generatedMinute == minutes)
        {
            txtTask1Result.text = "WELL DONE!";
            txtTask1Result.color = Color.green;
            GameManager.instance.AddPoints(1);
            GenerateTime();
            hourPointer.GetComponent<HourPointer>().ResetTime();
            minutePointer.GetComponent<MinutePointer>().ResetTime();
        }
        else
        {
            txtTask1Result.text = "TRY AGAIN!";
            txtTask1Result.color = Color.red;
        }
    }

    IEnumerator DisplayTaskResultMessage()
    {
        txtTask1Result.enabled = true;
        yield return new WaitForSeconds(1f);
        txtTask1Result.enabled = false;
    }

}
