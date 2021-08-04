using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector3 offset;
    
    void FixedUpdate()
    {
        Vector3 desirePosition = target.position + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothedposition;
        //transform.LookAt(target);
    }
}
