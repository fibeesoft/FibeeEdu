using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinutePointer : MonoBehaviour
{
    [SerializeField] GameObject hourPointer;
    ClockTower_MoveClockPointers clockTowerMoveClockPointer;
    Vector3 VScreen = new Vector3();
    Vector3 VWorld = new Vector3();


    private void Start()
    {
        clockTowerMoveClockPointer = FindObjectOfType<ClockTower_MoveClockPointers>();
    }
    private void Update()
    {

    }

    private void OnMouseDrag()
    {
        
        VScreen.x = Input.mousePosition.x;
        VScreen.y = Input.mousePosition.y;
        VScreen.z = Camera.main.transform.position.z;
        VWorld = Camera.main.ScreenToWorldPoint(VScreen);
        Vector3 dir = VWorld - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f ;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        float minuteAngle = 360f - transform.localEulerAngles.z;
        int minute = minuteAngle < 357f ? Mathf.RoundToInt(minuteAngle / 6) : 59;
        clockTowerMoveClockPointer.GetMinutes(minute);
        //print(transform.position.x);
        //print(transform.localPosition.x);
        //print(dir);
        print("minute: " + minute);
    }
    public void ResetTime()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
}
