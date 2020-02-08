using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Animations : MonoBehaviour
{
    public static Animations instance;
    [SerializeField] Button btnBack;
    [SerializeField] GameObject classPickContainer;
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
