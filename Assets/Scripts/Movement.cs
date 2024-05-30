using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private int speed = 5;
    private int rotationSpeed = 100;
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
        //rb.velocity = new Vector3(direction.x * speed, 0, direction.z * speed);
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * moveInput.x);

    }

    public void Forwards(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        direction = new Vector3(moveInput.x, 0, moveInput.y);
    }

}
