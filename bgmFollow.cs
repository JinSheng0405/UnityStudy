using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmFollow : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform targetPos2;
    // Update is called once per frame
    void Update()
    {
        if (729 >= Time.frameCount)
        {
            var targetPosition = targetPos.TransformPoint(0, 0, 0);
            transform.position = targetPosition;
        }
        else
        {
            var targetPosition = targetPos2.TransformPoint(0, 0, 0);
            transform.position = targetPosition;
        }
    }
}
