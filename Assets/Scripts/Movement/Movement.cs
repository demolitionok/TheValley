using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementRef;
    private InputAction movementAction;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private float movementSpeed;

    private float currentMovementSpeed;

    private Vector2 movementDirection;

    public void ReadPlayer(Player player) 
    {
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
    }


    private void Awake()
    {
        movementAction = movementRef.action;
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
        currentMovementSpeed = input.magnitude * movementSpeed;
        var isMoving = currentMovementSpeed > 0;
        
        if (isMoving)
        {
            animator.SetFloat("movementX", movementDirection.x);
            animator.SetFloat("movementY", movementDirection.y);
        }
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("movingStraightY", movementDirection.x == 0);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(currentMovementSpeed * Time.deltaTime * movementDirection + rb.position);
    }
}
