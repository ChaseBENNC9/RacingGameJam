 ///<remarks>
/// Author: Erika Stuart
/// Last Modified by: Chase Bennett-Hill
/// Date Created: 30/5/2023
/// Last Updated: 11/6/2023
/// Bugs: None
/// </remarks>

/// <summary>
/// This script is used to control the player in the game using the input system.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))] //Ensures that the object always has a rigidbody component
public class PlayerController : MonoBehaviour
{
    private int speed = 35;
    private int rotationSpeed = 100;
    private Vector2 moveInput;
    private Vector3 direction;
    private Rigidbody rb;
    public GameObject fillCircle;

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
    /// </summary>
    public void Forwards(InputAction.CallbackContext context)
    {
        if (GameManager.currentGameState == GameState.Racing)
        {
            moveInput = context.ReadValue<Vector2>();
            direction = new Vector3(moveInput.x, 0, moveInput.y);
        }
    }

    /// <summary>
    /// When the player holds the respawn button, the player will respawn at the last checkpoint.
    /// </summary>
    public void Respawn(InputAction.CallbackContext context)
    {
        if (CheckpointManager.inst.GetLastCheckpoint() != null)
        {
            if (context.started)
            {
                fillCircle.SetActive(true);
                fillCircle.GetComponent<Animator>().Play("FillCircle");
            }
            if (context.performed)
            {
                gameObject.transform.rotation = 
                    CheckpointManager.inst.GetLastCheckpoint().transform.rotation;

                gameObject.transform.position = CheckpointManager.inst.GetLastCheckpoint().spawnPoint.position;
                rb.velocity = Vector3.zero;

                fillCircle.SetActive(false);
            }
            if (context.canceled)
            {
                fillCircle.SetActive(false);
            }
        }
    }
}
