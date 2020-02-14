using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dividing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtFirstNumber;
    [SerializeField] TMP_InputField inpAnswer;
    [SerializeField] Slider sliderLevel;
    int num1, num2;
    void Start()
    {
        CreateTask();
        
    }

    public string Solution()
    {
        return (num1 / num2).ToString();
    }

    void Success()
    {
        Animations.instance.AnimateCheckButton(true);
        Animations.instance.DisplayResultMessage(true);
        GameManager.instance.AddPoints(1);
        CreateTask();
    }
    void Fail()
    {
        Animations.instance.AnimateCheckButton(false);
        Animations.instance.DisplayResultMessage(false);
        inpAnswer.text = "";
    }

    public void CreateTask()
    {
        GenerateRandomNumbers();
        MainUI.instance.SetInfo(Solution());
    }
    void GenerateRandomNumbers()
    {
        inpAnswer.text = "";
        int level = (int)sliderLevel.value;
        int maxValueNum1, maxValueNum2, minValueNum1, minValueNum2;
        if (level == 1)
        {
            minValueNum1 = 10;
            maxValueNum1 = 100;
            minValueNum2 = 2;
            maxValueNum2 = 10;

        }
        else if (level == 2)
        {
            minValueNum1 = 100;
            maxValueNum1 = 500;
            minValueNum2 = 3;
            maxValueNum2 = 10;
        }
        else if (level == 3)
        {
            minValueNum1 = 500;
            maxValueNum1 = 5000;
            minValueNum2 = 3;
            maxValueNum2 = 10;
        }
        else if (level == 4)
        {
            minValueNum1 = 2000;
            maxValueNum1 = 10000;
            minValueNum2 = 8;
            maxValueNum2 = 20;
        }
        else
        {
            minValueNum1 = 4000;
            maxValueNum1 = 100000;
            minValueNum2 = 11;
            maxValueNum2 = 30;
        }
        num1 = Random.Range(minValueNum1, maxValueNum1);
        num2 = Random.Range(minValueNum2, maxValueNum2);
        if(num1%num2 != 0)
        {
            GenerateRandomNumbers();
        }
        txtFirstNumber.text = $"{num1} : {num2}";
    }

    public void Check()
    {
        if(Solution() == inpAnswer.text)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }
}
