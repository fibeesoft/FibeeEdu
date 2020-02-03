using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourPointer : MonoBehaviour
{
    Vector3 VScreen = new Vector3();
    Vector3 VWorld = new Vector3();
    ClockTowerManager ClockTower;

    private void Start()
    {
        ClockTower = FindObjectOfType<ClockTowerManager>();
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
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        float minuteAngle = 360f - transform.localEulerAngles.z;

        int hour = (int)( minuteAngle / 30);
        ClockTower.GetHours(hour);
    }

    public void ResetTime()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }



}
