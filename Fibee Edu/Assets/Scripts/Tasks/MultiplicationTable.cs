﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplicationTable : MonoBehaviour
{
    [SerializeField] Text txtExpression, txtMessage;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Slider sliderMaxValue;
    [SerializeField] TextMeshProUGUI txtMaxValue;

    int num1, num2, result, maxValue;
    void Start()
    {
        GameManager.instance.SwitchTask(Tasks.MultiplicationTable);
        ChangeCheckButtonColor(new Color32(0,185,255,255));
        txtMessage.enabled = false;
        CreateExpression();
        DisplayMaxValue();

    }



    public string Solution()
    {
        return result.ToString();
    }

    void CreateExpression()
    {
        maxValue = (int)sliderMaxValue.value;
        num1 = Random.Range(1, maxValue + 1);
        num2 = Random.Range(1, maxValue + 1);
        result = num1 * num2;
        txtExpression.text = $"{num1} x {num2} = ";
        inpAnswer.ActivateInputField();
        inpAnswer.text = "";
        MainUI.instance.SetSolution(Solution());
    }

    public void DisplayMaxValue()
    {
        txtMaxValue.text = "MAX VALUE: " + (int)sliderMaxValue.value;
        CreateExpression();
    }
    void ChangeCheckButtonColor(Color c)
    {
        txtMessage.color = c;
    }

    public void CheckAnswer()
    {
        if(inpAnswer.text.Trim() == Solution())
        {
            Animations.instance.DisplayResultMessage(true);
            ChangeCheckButtonColor(Color.green);
            GameManager.instance.AddPoints(1);
            Animations.instance.AnimateCheckButton(true);
            CreateExpression();
            
        }
        else
        {
            Animations.instance.DisplayResultMessage(false);
            ChangeCheckButtonColor(Color.red);
            inpAnswer.ActivateInputField();
            Animations.instance.AnimateCheckButton(false);
            inpAnswer.text = "";
        }
        StartCoroutine(WaitAndChangeButtonColor());

    }

    IEnumerator WaitAndChangeButtonColor()
    {
        yield return new WaitForSeconds(1);
        ChangeCheckButtonColor(new Color32(0, 185, 255, 255));
    }
}
