using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Animations : MonoBehaviour
{
    public static Animations instance;
    [SerializeField] Button btnBack;
    [SerializeField] GameObject classPickContainer;
    [SerializeField] TextMeshProUGUI txtAnswerMessage;
    [SerializeField] TextMeshProUGUI  txtResultMessage;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AnimBtnBack()
    {
        btnBack.GetComponent<Animator>().SetTrigger("StartAnim");
    }

    public void AnimateClassPickContainer(bool isSwitchingOn)
    {
   
        Animator anim = classPickContainer.GetComponent<Animator>();
        if (!isSwitchingOn)
        {
            anim.SetTrigger("EndAnim");

        }
        else
        {
            anim.SetTrigger("StartAnim");
        }

    }


    public void AnimateCheckButton(bool isCorrect)
    {
        Animator btnCheckAnim = GameObject.FindObjectOfType<CheckButton>().GetComponent<Animator>();
      
            if (isCorrect)
            {
            btnCheckAnim.SetTrigger("buttonGoodAnswer");
            }
            else
            {
            btnCheckAnim.SetTrigger("buttonBadAnswer");
            }

    }

    public void DisplayResultMessage(bool b)
    {
        txtResultMessage.gameObject.SetActive(true);
        if (b)
        {
            txtResultMessage.text = "WELL DONE!";
            txtResultMessage.color = Color.green;
        }
        else
        {
            txtResultMessage.text = "TRY AGAIN!";
            txtResultMessage.color = Color.red;
        }
        StartCoroutine(AfterCheck());
    }
    IEnumerator AfterCheck()
    {
        yield return new WaitForSeconds(1f);
        txtResultMessage.gameObject.SetActive(false);
    }
}
