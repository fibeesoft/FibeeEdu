using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTower_ReadTime : MonoBehaviour
{
    [SerializeField] GameObject minutePointer;
    [SerializeField] GameObject hourPointer;
    [SerializeField] TextMeshProUGUI txtTask1Result, txtTimeOfTheDay, txtMinute, txtHour;
    [SerializeField] Slider slider12_24Switch, sliderMinute, sliderHour;

    int minute, hour;

    void Start()
    {
        txtTimeOfTheDay.gameObject.SetActive(false);
        GenerateRandomTime();
    }

    public void GenerateRandomTime()
    {
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
        print(minute);
        print(hour);
        minutePointer.transform.localRotation = Quaternion.Euler(0f, 0f, -minute * 6);
        hourPointer.transform.localRotation = Quaternion.Euler(0f, 0f, -temp_hour * 30 - (minute / 2f));
    }

    
    public void Check()
    {
        if(sliderMinute.value == minute && sliderHour.value == hour)
        {
            txtTask1Result.text = "WELL DONE!";
            GameManager.instance.AddPoints(1);
            ChangeColor(Color.green);
            GenerateRandomTime();
        }
        else
        {
            ChangeColor(Color.red);
            txtTask1Result.text = "TRY AGAIN!";

        }
        txtTask1Result.gameObject.SetActive(true);
        StartCoroutine(AfterCheck());
    }

    void ChangeColor(Color c)
    {
        txtTask1Result.color = c;
    }

    IEnumerator AfterCheck()
    {
        yield return new WaitForSeconds(1f);
        txtTask1Result.gameObject.SetActive(false);
        ResetTxtMinuteHour();
    }

    void Update()
    {
        
    }

    public void ResetTxtMinuteHour()
    {
        txtMinute.text = "00";
        txtHour.text = "00";
    }

    public void UpdateHourMinuteSliders()
    {
        txtMinute.text = sliderMinute.value.ToString("00");
        txtHour.text = sliderHour.value.ToString("00");
    }
}
