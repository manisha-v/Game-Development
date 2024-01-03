using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform plane;


    // Update is called once per frame
    void Update()
    {
        if (plane == null)
            return;
        transform.position = new Vector3(plane.position.x, transform.position.y, transform.position.z);
    }
}
