using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MultiplicationInColumn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtFirstNumber, txtSecondNumber;
    [SerializeField] TMP_InputField inpAnswer;
    [SerializeField] Slider sliderLevel;
    int num1, num2;
    //Levels
    // 1 - 10-99, 1-9
    // 2 - 10-99, 10-99
    // 3 - 100-999, 10-99
    // 4 - 100-999, 100-999
    // 5 - 1000-9999, 100-999
    void Start()
    {
        CreateTask();
    }

    void Update()
    {
        
    }

    public int GetSliderLevel()
    {
        return (int)sliderLevel.value;
    }

    public void CreateTask()
    {
        GenerateRandomNumbers();
        UpdateTextFields();
    }

    public void Check()
    {
        if(inpAnswer.text == (num1 * num2).ToString())
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
    void GenerateRandomNumbers()
    {
        int maxValueNum1, maxValueNum2, minValueNum1, minValueNum2;
        int level = GetSliderLevel();
        if(level == 1)
        {
            minValueNum1 = 10;
            maxValueNum1 = 100;
            minValueNum2 = 1;
            maxValueNum2 = 10;

        }
        else if(level == 2)
        {
            minValueNum1 = 10;
            maxValueNum1 = 100;
            minValueNum2 = 10;
            maxValueNum2 = 100;
        }
        else if (level == 3)
        {
            minValueNum1 = 100;
            maxValueNum1 = 1000;
            minValueNum2 = 10;
            maxValueNum2 = 100;
        }
        else if (level == 4)
        {
            minValueNum1 = 100;
            maxValueNum1 = 1000;
            minValueNum2 = 100;
            maxValueNum2 = 1000;
        }
        else
        {
            minValueNum1 = 1000;
            maxValueNum1 = 10000;
            minValueNum2 = 100;
            maxValueNum2 = 1000;
        }

        num1 = Random.Range(minValueNum1, maxValueNum1);
        num2 = Random.Range(minValueNum2, maxValueNum2);

    }

    void UpdateTextFields()
    {
        txtFirstNumber.text = num1.ToString();
        txtSecondNumber.text = num2.ToString();
        inpAnswer.text = "";
    }
}
