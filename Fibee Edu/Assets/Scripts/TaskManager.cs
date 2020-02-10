using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private void OnEnable()
    {
        MainUI.instance.ActivateTaskSpecificButtons(true);
    }

    private void OnDisable()
    {
        MainUI.instance.ActivateTaskSpecificButtons(false);
    }
}
