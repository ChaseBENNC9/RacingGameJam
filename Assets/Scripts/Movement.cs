using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private int speed = 20;
    private int rotationSpeed = 100;
    private float acceleration = 0.2f;
    private Vector2 moveInput;
    private Vector3 direction;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime, Space.Self);
        rb.AddForce(transform.forward * speed * moveInput.y);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * moveInput.x);

    }

    public void Forwards(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        direction = new Vector3(moveInput.x, 0, moveInput.y);
    }

}
