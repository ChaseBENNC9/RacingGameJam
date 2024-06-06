///<remarks>
/// Author: Erika Stuart
/// Date Created: 30/5/2023
/// Last Updated: 1/6/2023
/// Bugs: None
/// </remarks>

/// <summary>
/// This script is used to move the player in the game using the input system.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private int speed = 100;
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
        rb.AddForce(transform.forward * speed * moveInput.y);
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * moveInput.x);
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
