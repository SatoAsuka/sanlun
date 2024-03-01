using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    void FixedUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetpos = target.position;
                transform.position = Vector3.Lerp(targetpos, transform.position, smoothing);
            }
        }
    }
}
