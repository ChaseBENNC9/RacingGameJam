///<remarks>
/// Author: Erika Stuart
/// Date Created: 30/5/2023
/// Last Updated: 1/6/2023
/// Bugs: None
/// </remarks>

/// <summary>
/// This script is used to move the player in the game using the input system.
/// </summary>

// https://docs.unity3d.com/Manual/WheelColliderTutorial.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float motorTorque = 200;
    public float brakeTorque = 2000;
    private int speed = 10000;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public float centreOfGravityOffset = -1f;
    WheelControl[] wheels;

    private Rigidbody rb;

    //private int rotationSpeed = 100;
    private Vector2 moveInput;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.centerOfMass += Vector3.up * centreOfGravityOffset;
        wheels = GetComponentsInChildren<WheelControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * speed * moveInput.y);
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * moveInput.x);

        float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);

        float speedFactor = Mathf.InverseLerp(0, speed, forwardSpeed);
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
        bool isAccelerating = Mathf.Sign(moveInput.y) == Mathf.Sign(forwardSpeed);

        foreach (WheelControl wheel in wheels)
        {
            if (wheel.steerable)
            {
                wheel.wheelCollider.steerAngle = currentSteerRange * moveInput.x;
            }
             if (isAccelerating)
            {
                if (wheel.motorized)
                {
                    wheel.wheelCollider.motorTorque = moveInput.y * currentMotorTorque;
                }
                wheel.wheelCollider.brakeTorque = 0;
            }
            else
            {
                wheel.wheelCollider.brakeTorque = Mathf.Abs(moveInput.y) * brakeTorque;
                wheel.wheelCollider.motorTorque = 0;
            }
        }
    }

    /// <summary>
    /// When the player uses the input system, the player will move.
    public void Forwards(InputAction.CallbackContext context)
    {
        if (GameManager.currentGameState == GameState.Racing)
        {
            moveInput = context.ReadValue<Vector2>();
            direction = new Vector3(moveInput.x, 0, moveInput.y);
        }
    }
}
