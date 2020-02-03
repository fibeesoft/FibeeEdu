using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTowerManager : MonoBehaviour
{
    [SerializeField] GameObject minutePointer;
    [SerializeField] GameObject hourPointer;
    void Start()
    {
        hourPointer.transform.localRotation = Quaternion.Euler(0f, 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
