using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{
    public Transform Target;
    public float smoothing = 5f;
    Vector3 offSet;
    public float z;

    // Use this for initialization
    void Awake()
    {
        offSet = transform.position - Target.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = Target.position + offSet;
        camPos.z = camPos.z - z;
        transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);

    }
}
