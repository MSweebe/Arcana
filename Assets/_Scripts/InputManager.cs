using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float camInputX;
    public float camInputY;

    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool jumpInput;

    private void Awake() 
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable() 
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.Jump.performed += i => jumpInput = true;
        }

        playerControls.Enable();
    }
    
    private void OnDisable() 
    {
        playerControls.Disable();
    }

    public void HandleAllInput() 
    {
        HandleMovementInput();
        HandleJumpInput();
        //HandleActionInput
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        camInputX = cameraInput.x;
        camInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleJumpInput()
    {
        if(jumpInput)
        {
            jumpInput = false;
            playerLocomotion.HandleJump();
        }
    }
}

