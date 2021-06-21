using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollow : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 temPos;
    // Update is called once per frame
    void Update()
    {
        HandleTranslation();
        HandleRotation();
    }
    private void HandleTranslation()
    {
        var targetPosition = targetPos.TransformPoint(offset);
        //Debug.Log("666"+targetPosition);
        //Debug.Log(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var diretion = targetPos.position - transform.position;
        //Debug.Log(diretion);
        temPos = new Vector3(0, 1, 0);
        var rotation = Quaternion.LookRotation(diretion, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }


}
