using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplicationTable : MonoBehaviour
{
    [SerializeField] Text txtExpression, txtMessage;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Button buttonCheck;
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

    void CreateExpression()
    {
        maxValue = (int)sliderMaxValue.value;
        num1 = Random.Range(1, maxValue + 1);
        num2 = Random.Range(1, maxValue + 1);
        result = num1 * num2;
        txtExpression.text = $"{num1} x {num2} = ";
        inpAnswer.ActivateInputField();
        inpAnswer.text = "";
        
    }

    public void DisplayMaxValue()
    {
        txtMaxValue.text = "MAX VALUE: " + (int)sliderMaxValue.value;
        CreateExpression();
    }
    void ChangeCheckButtonColor(Color c)
    {
        buttonCheck.image.color = c;
        txtMessage.color = c;
    }

    public void CheckAnswer()
    {
        if(inpAnswer.text.Trim() == result.ToString())
        {
            ChangeCheckButtonColor(Color.green);
            StartCoroutine( DisplayMessage("Well done!"));
            GameManager.instance.AddPoints(1);
            CreateExpression();
            
        }
        else
        {
            ChangeCheckButtonColor(Color.red);
            StartCoroutine(DisplayMessage("Try again!"));
            inpAnswer.ActivateInputField();
            inpAnswer.text = "";
        }

    }
    void Update()
    {
        
    }

    IEnumerator DisplayMessage(string mess)
    {
        txtMessage.enabled = true;
        txtMessage.text = mess;
        yield return new WaitForSeconds(1);
        txtMessage.enabled = false;
        ChangeCheckButtonColor(new Color32(0, 185, 255, 255));
    }
}
