using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTower_ReadTime : MonoBehaviour
{
    [SerializeField] GameObject minutePointer;
    [SerializeField] GameObject hourPointer;
    [SerializeField] TextMeshProUGUI txtTimeOfTheDay, txtMinute, txtHour;
    [SerializeField] Slider slider12_24Switch, sliderMinute, sliderHour;

    int minute, hour;
    float minuteAngle, hourAngle, tempMinuteAngle = 0, tempHourAngle = 0;
    float pointerSpeed = 150f;

    void Start()
    {
        GameManager.instance.SwitchTask(Tasks.ClockTowerReadTime);
        txtTimeOfTheDay.gameObject.SetActive(false);
        GenerateRandomTime();
    }

    public void GenerateRandomTime()
    {
        tempMinuteAngle = 0;
        tempHourAngle = 0;
        sliderHour.value = 0;
        sliderMinute.value = 0;
        minute = Random.Range(0, 60);
        if(slider12_24Switch.value == 0)
        {
            hour = Random.Range(0, 12);
            sliderHour.maxValue = 11;
            txtTimeOfTheDay.gameObject.SetActive(false);
        }
        else
        {
            hour = Random.Range(0, 24);
            sliderHour.maxValue = 23;
            if (hour < 12)
            {
                txtTimeOfTheDay.text = "AM";
            }
            else
            {
                txtTimeOfTheDay.text = "PM";
            }
            txtTimeOfTheDay.gameObject.SetActive(true);
        }
        MoveClockPointers();
    }

    public void MoveClockPointers()
    {
        int temp_hour = hour < 12 ? hour : hour - 12;
        minuteAngle = -minute * 6;
        hourAngle = -temp_hour * 30 - (minute / 2f);

    }

    void Update()
    {
 
        if(tempMinuteAngle > minuteAngle)
        {
            tempMinuteAngle -= Time.deltaTime * pointerSpeed + -minuteAngle * Time.deltaTime;
            minutePointer.transform.localEulerAngles = new Vector3(0f, 0f, tempMinuteAngle);
        }
        if (tempHourAngle > hourAngle)
        {
            tempHourAngle -= Time.deltaTime * pointerSpeed + -hourAngle * Time.deltaTime;
            hourPointer.transform.localEulerAngles = new Vector3(0f, 0f, tempHourAngle);
        }
        
    }
    
    public void Check()
    {
        if(sliderMinute.value == minute && sliderHour.value == hour)
        {
            GameManager.instance.DisplayResultMessage(true);
            GameManager.instance.AddPoints(1);
            GenerateRandomTime();
        }
        else
        {
            GameManager.instance.DisplayResultMessage(false);
        }
    }





    public void ResetTxtMinuteHour()
    {
        sliderHour.value = 0;
        sliderMinute.value = 0;
        UpdateHourMinuteSliders();
    }

    public void UpdateHourMinuteSliders()
    {
        txtMinute.text = sliderMinute.value.ToString("00");
        txtHour.text = sliderHour.value.ToString("00");
    }
}
