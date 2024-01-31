using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputSystem : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    Vector2 moveDirection = Vector2.zero;
    Vector2 rotateDirection = Vector2.zero;

    private void Update()
    {

        OldInputSystemMovement();
        OldInputSystemRotation();

    }

    private void OldInputSystemRotation()
    {
        transform.Rotate(new Vector3(0, OldSystemRotationDirection().x, 0) * (rotationSpeed * Time.deltaTime));
    }

    private void OldInputSystemMovement()
    {
        transform.position += this.transform.rotation * new Vector3(0, 0, OldSystemMovementDirection().y) * (movementSpeed * Time.deltaTime);
    }

    private Vector2 OldSystemMovementDirection()
    {

        if (InputHandler.WalkForwardInput())
        {

            moveDirection += Vector2.up;

        }

        if (InputHandler.WalkBackwardInput())
        {

            moveDirection += Vector2.down;

        }

        if (!InputHandler.WalkForwardInput() && !InputHandler.WalkBackwardInput())
        {

            moveDirection = Vector2.zero;

        }

        return moveDirection.normalized;

    }

    private Vector2 OldSystemRotationDirection()
    {

        if (InputHandler.RotateRightInput())
        {

            rotateDirection += Vector2.right;

        }
        if (InputHandler.RotateLeftInput())
        {

            rotateDirection += Vector2.left;

        }
        if (!InputHandler.RotateRightInput() && !InputHandler.RotateLeftInput())
        {

            rotateDirection = Vector2.zero;

        }

        return rotateDirection.normalized;

    }

}