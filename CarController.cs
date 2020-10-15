using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject  Front_Left_Wheel_Object;
    public GameObject Front_Right_Wheel_Object;
    public GameObject Back_Left_Wheel_Object;
    public GameObject Back_Right_Wheel_Object;

    public WheelCollider Front_Left_Wheel_Component;
    public WheelCollider Front_Right_Wheel_Component;
    public WheelCollider Back_Left_Wheel_Component;
    public WheelCollider Back_Right_Wheel_Component;


    public float maxSpeed;
    public float maxSteer;


    private void FixedUpdate()
    {

        float motorT = Input.GetAxis("Vertical") * maxSpeed;
        float steerT = Input.GetAxis("Horizontal") * maxSteer;




        // Steers
        // Front Wheels

        Front_Left_Wheel_Component.steerAngle = steerT;
        Front_Right_Wheel_Component.steerAngle = steerT;

        // Move
        // Back Weels

        Back_Left_Wheel_Component.motorTorque = motorT;
        Back_Right_Wheel_Component.motorTorque = motorT;

        // Get Rotation For Wheels Objects

        // wheel top right
        Vector3 pos;
        Quaternion rotationQ;
        Front_Left_Wheel_Component.GetWorldPose(out pos, out rotationQ);
        Front_Left_Wheel_Object.transform.position = pos;
        Front_Left_Wheel_Object.transform.rotation = rotationQ;

        // wheel top left
        Vector3 pos1;
        Quaternion rotationQ1;
        Front_Right_Wheel_Component.GetWorldPose(out pos1, out rotationQ1);
        Front_Right_Wheel_Object.transform.position = pos1;
        Front_Right_Wheel_Object.transform.rotation = rotationQ1;


        // wheel Bottom right
        Vector3 pos2;
        Quaternion rotationQ2;
        Back_Left_Wheel_Component.GetWorldPose(out pos2, out rotationQ2);
        Back_Left_Wheel_Object.transform.position = pos2;
        Back_Left_Wheel_Object.transform.rotation = rotationQ2;

        // wheel Bottom left
        Vector3 pos3;
        Quaternion rotationQ3;
        Back_Right_Wheel_Component.GetWorldPose(out pos3, out rotationQ3);
        Back_Right_Wheel_Object.transform.position = pos3;
        Back_Right_Wheel_Object.transform.rotation = rotationQ3;



        
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.01f)
        {

            Back_Left_Wheel_Component.brakeTorque = 0;
            Back_Right_Wheel_Component.brakeTorque = 0;
            
        } else
        {

            Back_Left_Wheel_Component.brakeTorque = 400f;
            Back_Right_Wheel_Component.brakeTorque = 400f;

        }
        



    }











}
