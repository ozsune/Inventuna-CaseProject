using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform CurrentTarget;
    public float Speed;

    [SerializeField] private Vector3 Offset;
    
    public void SetTarget()
    {
        CurrentTarget = FindObjectOfType<PlayerController>().transform;
    }
    
    private void Update()
    {
        if(CurrentTarget != null)
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.position + Offset, Speed * Time.deltaTime);
    }
}
