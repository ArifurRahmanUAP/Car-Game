using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
	public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}
     [SerializeField]
	 private float speed= 0.0f;
    [SerializeField]
    private float maxAcceleration = 15.0f;
    [SerializeField]
    private float turnSensitivity = 1.0f;
    [SerializeField]
    private float maxSteerAngle = 45.0f;
    [SerializeField]
    private Vector3 _centerOfMass;
    [SerializeField]
    private List<Wheel> wheels;

    private float inputX, inputY=0.0f;

    private Rigidbody _rb;

    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass;
    }

    
    private void Update()
    {
		speed+=.01f*Time.deltaTime;
        AnimateWheels();
        GetInputs();
		inputY +=speed*Time.deltaTime;
		Move();
        Turn();
    }

    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }
    }

    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle,_steerAngle,0.5f);
            }
        }
    }

    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
}
