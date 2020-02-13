﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject minuteHandler, hourHandler;
    [SerializeField] TextMeshProUGUI txtHourDigital, txtMinuteDigital;
    [SerializeField] Slider sliderHour, sliderMinute, sliderOptions;
    [SerializeField] Button btnCheck;
    bool is24hourOn = false;
    bool isReadOn;
    int generatedHour, generatedMinute;
    void Start()
    {
        MainUI.instance.SetExplanation("This task comes in two options to choose from. We can either read the analog clock, use sliders to set the value on the digital clock or we can read the values and try to set the analog clock by sliding the sliders." +
            "\n We can choose READ, SET or RANDOM option. Once we set the analog or digital clock we can press the Check Button. If the answer is correct, new task will be generated automatically.");
        ;
        CreateTask();
    }


    void CalculateRandomTime()
    {
        int maxValue;
        if (is24hourOn)
        {
            maxValue = 24;
        }
        else
        {
            maxValue = 12;
        }

        generatedHour = Random.Range(0, maxValue);
        generatedMinute = Random.Range(0, 60);
        
        sliderHour.maxValue = maxValue - 1;
        sliderMinute.maxValue = 59;
    }

    public void SetTheAnalogClock()
    {
        if (isReadOn)
        {
            float minuteAngle = -generatedMinute * 6;
            float hourAngle = -generatedHour * 30 - generatedMinute/2;
            minuteHandler.transform.localEulerAngles = new Vector3(0f, 0f, minuteAngle);
            hourHandler.transform.localEulerAngles = new Vector3(0f, 0f, hourAngle);

        }
        else
        {
            float minuteAngle = -sliderMinute.value * 6;
            float hourAngle = -sliderHour.value * 30 - sliderMinute.value / 2;
            minuteHandler.transform.localEulerAngles = new Vector3(0f, 0f, minuteAngle);
            hourHandler.transform.localEulerAngles = new Vector3(0f, 0f, hourAngle);
        }
    }

    public void SetTheDigitalClock()
    {
        if (isReadOn)
        {
            if(sliderHour.value == 0)
            {
                txtHourDigital.text = (sliderHour.value + 12).ToString("00");

            }
            else
            {
                txtHourDigital.text = sliderHour.value.ToString("00");
            }
            txtMinuteDigital.text = sliderMinute.value.ToString("00");
        }
        else
        {
            if(generatedHour == 0)
            {
                txtHourDigital.text = (generatedHour + 12).ToString("00");
            }
            else
            {
                txtHourDigital.text = generatedHour.ToString("00");
            }
            txtMinuteDigital.text = generatedMinute.ToString("00");
        }
    }

    public void Check()
    {
        if (sliderHour.value == generatedHour && sliderMinute.value == generatedMinute)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }

    void Success()
    {
        Animations.instance.DisplayResultMessage(true);
        Animations.instance.AnimateCheckButton(true);
        GameManager.instance.AddPoints(1);
        CreateTask();

    }

    void Fail()
    {
        Animations.instance.DisplayResultMessage(false);
        Animations.instance.AnimateCheckButton(false);
    }

    void SetTheOption()
    {
        if(sliderOptions.value == 0)
        {
            isReadOn = true;
        }
        else if(sliderOptions.value == 1)
        {
            isReadOn = false;
        }
        else
        {
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                isReadOn = true;
            }
            else
            {
                isReadOn = false;
            }
        }
    }

    public void CreateTask()
    {
        ResetAllValues();
        SetTheOption();
        CalculateRandomTime();
        SetTheAnalogClock();
        SetTheDigitalClock();
    }

    void ResetAllValues()
    {
        sliderHour.value = 0;
        sliderMinute.value = 0;
        minuteHandler.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        hourHandler.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        txtHourDigital.text = "00";
        txtMinuteDigital.text = "00";
    }

}
