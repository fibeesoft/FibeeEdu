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

    public void AnimateAnswerResultText(bool isCorrect)
    {
        StartCoroutine(AnimateAnswerResultTextCor());

        IEnumerator AnimateAnswerResultTextCor()
        {
            txtAnswerMessage.gameObject.SetActive(true);
            if (isCorrect)
            {
                txtAnswerMessage.color = Color.green;
                txtAnswerMessage.text = "WELL DONE!";
            }
            else
            {
                txtAnswerMessage.color = Color.red;
                txtAnswerMessage.text = "TRY AGAIN!";
            }

            yield return new WaitForSeconds(1.0f);
            txtAnswerMessage.gameObject.SetActive(false);
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
}
