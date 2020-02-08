using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomPicker : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ZoomInClassRoomPicker()
    {
        anim.SetTrigger("EndAnim");
    }

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("StartAnim");
    }

}
