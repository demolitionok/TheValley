using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private InputActionReference movementRef;
    private InputAction movementAction;

    [SerializeField]
    private float movementSpeed;

    private Vector2 movementDirection;

    private void Awake()
    {
        var movementAction = movementRef.action;
    }

    private void OnEnable()
    {
        movementAction.performed += OnMovement;
        movementAction.canceled += OnMovement;
    }
    private void OnDisable()
    {
        movementAction.performed -= OnMovement;
        movementAction.canceled -= OnMovement;
    }


    private void OnMovement(InputAction.CallbackContext ctx) 
    {
        var input = ctx.ReadValue<Vector2>();
        movementDirection = input.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(movementSpeed * Time.deltaTime * movementDirection + rb.position);
    }
}
