﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    bool isNewPositionSet = false;
    RaycastHit hit;
    Ray ray;
    Vector3 nextPos;
    void Update()
    {

        bool RMB = Input.GetMouseButtonDown(1);

        if (RMB)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Ground"))
            {

                nextPos = hit.point;
                isNewPositionSet = true;
            }
        }
        if (isNewPositionSet)
        {
            if (Vector3.Distance(transform.position, hit.point) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, 12 * Time.deltaTime);
                

            }
            else
            {
                isNewPositionSet = false;
            }
        }
    }
}
