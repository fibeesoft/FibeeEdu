using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplicationTable : MonoBehaviour
{
    [SerializeField] Text txtExpression, txtMessage;
    [SerializeField] InputField inpAnswer;
    [SerializeField] Button buttonCheck;

    int num1, num2, result, maxValue = 10;
    void Start()
    {
        txtMessage.enabled = false;
        CreateExpression();
    }

    void CreateExpression()
    {
        num1 = Random.Range(1, maxValue + 1);
        num2 = Random.Range(1, maxValue + 1);
        result = num1 * num2;
        txtExpression.text = $"{num1} x {num2} = ";
        inpAnswer.ActivateInputField();
        inpAnswer.text = "";
    }

    public void CheckAnswer()
    {
        if(inpAnswer.text.Trim() == result.ToString())
        {
            StartCoroutine( DisplayMessage("Well done!"));
            GameManager.instance.AddPoints(1);
            CreateExpression();
            
        }
        else
        {

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
    }
}
