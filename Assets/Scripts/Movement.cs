using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private int speed = 5;
    private Vector2 moveInput;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Forwards(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        move = new Vector3(moveInput.x, 0, moveInput.y);
    }

}
