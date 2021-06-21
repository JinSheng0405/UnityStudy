using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womanFollow : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        var targetPosition = targetPos.TransformPoint(offset);
        transform.position = targetPosition;
        transform.rotation = targetPos.rotation;
    }



}
