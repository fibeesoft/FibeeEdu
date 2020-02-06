using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SwitchTask(Tasks.NoTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
