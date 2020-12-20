using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, -10);
    }
}
