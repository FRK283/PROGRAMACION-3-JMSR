using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private InputSystem inputSystem;

    [SerializeField] private float speed = 6;
    [SerializeField] private float rotateSpeed = 17;
    [SerializeField] private float walkingSpeed = 7;
    [SerializeField] private float runningSpeed = 14;
    [SerializeField] private float jumpForce = .2f;

    Vector2 moveDirection = Vector2.zero;


    private Action Movement;
    private Action Rotation;
    private Action Shoot;
    private Action Jump;
    private Action Run;
    private Action Reload;

    private PlayerInput input;

    private Rigidbody playerRb;


    private void OnValidate()
    {
        switch (inputSystem)
        {
            case InputSystem.OldInputSystem:
                {
                    Movement = OldInputMovement;
                    Rotation = OldInputRotation;
                    Jump = OldInputJump;
                    Shoot = OldShootJump;
                    Reload = OldReload;
                    break;
                }

            case InputSystem.NewInputSystem:
                {
                    Movement = NewInputMovement;
                    Rotation = NewInputRotation;
                    Jump = NewJumpInput;
                    Shoot = NewShootInput;
                    Reload = NewReloadInput;
                    break;
                }
        }
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
        Rotation();
        Jump();
        Shoot();
        Reload();
    }

    void NewInputMovement()
    {
        playerRb.position += this.transform.rotation * new Vector3(x: 0, y: 0, z: NewMoveDirection()) * (NewActualSpeed() * Time.deltaTime);
        //transform.position += this.transform.rotation * new Vector3(x: 0, y: 0, z: NewMoveDirection()) * (ActualSpeed() * Time.deltaTime);
    }

    void NewInputRotation()
    {
        transform.Rotate(new Vector3(x: 0, y: NewRotateDirection(), z: 0) * (rotateSpeed * Time.deltaTime));
    }

    float NewMoveDirection()
    {
        return input.actions["Move"].ReadValue<Vector2>().y;
    }

    float NewRotateDirection()
    {
        return input.actions["Move"].ReadValue<Vector2>().x;
    }

    void OldInputMovement()
    {
        playerRb.position += this.transform.rotation * new Vector3(x: 0, y: 0, z: OldMoveDirection().y) * (OldActualSpeed() * Time.deltaTime);
       
    }

    void OldInputRotation()
    {
        transform.Rotate(new Vector3(x: 0, y: OldRotateDirection().x, z: 0) * (rotateSpeed * Time.deltaTime));
    }

    Vector2 OldMoveDirection()
    {
        if (InputHandler.MoveForwardInput())
        {
            moveDirection += Vector2.up;
        }

        if (InputHandler.MoveBackwardInput())
        {
            moveDirection += Vector2.down;
        }

        return moveDirection != Vector2.zero ? moveDirection.normalized : Vector2.zero;
    }

    Vector2 OldRotateDirection()
    {
        if (InputHandler.RotateLeftInput())
        {
            moveDirection += Vector2.left;
        }

        if (InputHandler.RotateRightInput())
        {
            moveDirection += Vector2.right;
        }

        return moveDirection != Vector2.zero ? moveDirection.normalized : Vector2.zero;
    }

    private float NewActualSpeed()
    {
        return input.actions["Run"].ReadValue<bool>() ? runningSpeed : walkingSpeed;
    }

    private float OldActualSpeed()
    {
        
        return InputHandler.RunInput() ? runningSpeed : walkingSpeed;
    }

    void NewJumpInput()
    {
        
        if (input.actions["Jump"].WasPressedThisFrame())
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("jump new");
        }
    }

    void OldInputJump()
    {
        if (InputHandler.JumpInput())
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          Debug.Log("jump old ");
        }
    }

    void NewShootInput()
    {
        if (input.actions["Shoot"].WasPressedThisFrame())
        {
            Debug.Log("new shoot");
        }
    }

    void OldShootJump()
    {
        if (InputHandler.ShootKey())
        {
            Debug.Log("old shoot ");
        }
    }

    void NewReloadInput()
    {
        if (input.actions["Reload"].WasPressedThisFrame())
        {
            Debug.Log("new reload como persona  3 reload 2 de febrero solo en gamepass ");
        }
    }

    void OldReload()
    {
        if (InputHandler.Reload())
        {
            Debug.Log("Old reload ");
        }
    }
}

public enum InputSystem
{
    OldInputSystem, NewInputSystem
}