using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassRoomButton : MonoBehaviour
{
    MenuManager menuManager;
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(PickTheClassRoom);
    }

public void PickTheClassRoom()
    {
        GameManager.instance.SetClass(System.Convert.ToInt32(gameObject.name));
    }
}
