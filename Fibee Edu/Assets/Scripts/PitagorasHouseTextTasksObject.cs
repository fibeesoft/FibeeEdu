using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitagorasHouseTextTasksObject : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.SwitchTask(Tasks.PitagorasHouseTextTasks);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        SceneChanger.instance.LoadScene((int)Scenes.PitagorasHouseTextTasks);
    }
}
