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
    }
    void GenerateRandomNumbers()
    {
        inpAnswer.text = "";
        int level = (int)sliderLevel.value;
        num1 = Random.Range(10 * (level <= 2 ? 1 : level - 1), level <= 2 ? 100 : (int)(10 * Mathf.Pow(10,level - 1 )));
        num2 = Random.Range(2, 10 * (level <= 2 ? 1 : level - 1));
        if(num1%num2 != 0)
        {
            GenerateRandomNumbers();
        }
        txtFirstNumber.text = $"{num1} : {num2}";
    }

    public void Check()
    {
        if((num1 / num2).ToString() == inpAnswer.text)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }
}
