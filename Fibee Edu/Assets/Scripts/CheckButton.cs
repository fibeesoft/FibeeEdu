using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{

    void Start()
    {

    }


    public void ActivateCheckButton(bool isGood)
    {
        if (isGood)
        {
            gameObject.GetComponent<Animator>().SetTrigger("buttonGoodAnswer");
        }
        else
        {
            gameObject.GetComponent<Animator>().SetTrigger("buttonBadAnswer");
        }
    }

}
