using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassRoomButton : MonoBehaviour
{
    MenuManager menuManager;
    [SerializeField] GameObject classRoomPicker;
    void Start()
    {

        GetComponent<Button>().onClick.AddListener(delegate { StartCoroutine(PickTheClassRoom()); });
    }

    IEnumerator PickTheClassRoom()
    {
        Animate();
        GameManager.instance.SetClass(System.Convert.ToInt32(gameObject.name));
        yield return new WaitForSeconds(0.2f);
        classRoomPicker.GetComponent<ClassRoomPicker>().ZoomInClassRoomPicker();
        yield return new WaitForSeconds(1.2f);
        classRoomPicker.SetActive(false);
    }

    void Animate()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("StartAnim");
    }
}
