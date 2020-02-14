using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplicationTable : MonoBehaviour
{
    [SerializeField] Text txtExpression;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Slider sliderMaxValue;
    [SerializeField] TextMeshProUGUI txtMaxValue;

    int num1, num2, result, maxValue;
    void Start()
    {
        CreateExpression();
    }

    public string Solution()
    {
        return result.ToString();
    }

    public void CreateExpression()
    {
        maxValue = (int)sliderMaxValue.value;
        txtMaxValue.text = "MAX VALUE: " + maxValue;
        num1 = Random.Range(1, maxValue + 1);
        num2 = Random.Range(1, maxValue + 1);
        result = num1 * num2;
        txtExpression.text = $"{num1} x {num2} = ";
        inpAnswer.ActivateInputField();
        inpAnswer.text = "";
        MainUI.instance.SetInfo(Solution());
    }

    public void CheckAnswer()
    {
        if(inpAnswer.text.Trim() == Solution())
        {
            Animations.instance.DisplayResultMessage(true);
            GameManager.instance.AddPoints(1);
            Animations.instance.AnimateCheckButton(true);
            CreateExpression();
            
        }
        else
        {
            Animations.instance.DisplayResultMessage(false);
            inpAnswer.ActivateInputField();
            Animations.instance.AnimateCheckButton(false);
            inpAnswer.text = "";
        }

    }
}
