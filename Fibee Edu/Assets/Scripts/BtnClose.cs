using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClose : MonoBehaviour
{
    Animator anim;
    Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        //btn.onClick.AddListener(delegate { ClickButton(); });
    }

    void ClickButton()
    {


    }
}
