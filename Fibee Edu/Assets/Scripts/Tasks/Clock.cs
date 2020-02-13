using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject minuteHandler, hourHandler;
    [SerializeField] TextMeshProUGUI txtHourDigital, txtMinuteDigital;
    [SerializeField] Image imgDayOrNight;
    [SerializeField] Sprite spriteDay, spriteNight;
    [SerializeField] Slider sliderHour, sliderMinute, sliderOptions, slider1224;
    [SerializeField] Button btnCheck;
    bool is24hourOn = false;
    bool isReadOn;
    int generatedHour, generatedMinute;
    void Start()
    {
        MainUI.instance.SetExplanation("This task comes in two options to choose from. We can either read the analog clock, use sliders to set the value on the digital clock or we can read the values and try to set the analog clock by sliding the sliders." +
            "\n We can choose READ, SET or RANDOM option. Once we set the analog or digital clock we can press the Check Button. If the answer is correct, new task will be generated automatically." +
            "\n\nThere is an option to switch between 12H and 24H system. The sun/moon icon appears to indicate the time of the day." +
            "\nThe day is 6.00 - 17:59 while the night starts at 18.00 - 5:59" +
            "\n");
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

            if(is24hourOn == false)
            {
                if(sliderHour.value == 0)
                {
                    txtHourDigital.text = (sliderHour.value + 12).ToString("00");

                }
                else
                {
                    txtHourDigital.text = sliderHour.value.ToString("00");
                }
                
            }
            else
            {
                if(generatedHour >= 6 && generatedHour < 18)
                {
                    imgDayOrNight.sprite = spriteDay;
                }
                else
                {
                    imgDayOrNight.sprite = spriteNight;
                }
                txtHourDigital.text = sliderHour.value.ToString("00");
            }
            txtMinuteDigital.text = sliderMinute.value.ToString("00");

        }
        else
        {
            if(is24hourOn == false)
            {
                if(generatedHour == 0)
                {
                    txtHourDigital.text = (generatedHour + 12).ToString("00");
                }
                else
                {
                    txtHourDigital.text = generatedHour.ToString("00");
                }
                
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
        if(slider1224.value == 0)
        {
            is24hourOn = false;
            imgDayOrNight.gameObject.SetActive(false);
        }
        else
        {
            is24hourOn = true;
            imgDayOrNight.gameObject.SetActive(true);
        }
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
        MainUI.instance.SetSolution(generatedHour + " : " + generatedMinute);
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
