using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private PlayerInput input;


    private void Start()
    {

        input = GetComponent<PlayerInput>();

    }

    private void Update()
    {

        NewInputSystemMovement();
        NewInputSystemRotation();

    }

    private void NewInputSystemMovement()
    {
        transform.position += this.transform.rotation * new Vector3(0, 0, NewInputSystemMovementDirection()) * (movementSpeed * Time.deltaTime);
    }

    private void NewInputSystemRotation()
    {

        transform.Rotate(new Vector3(0, NewInputSystemRotationDirection(), 0) * (rotationSpeed * Time.deltaTime));

    }

    private float NewInputSystemMovementDirection()
    {

        return input.actions["Move"].ReadValue<Vector2>().y;

    }

    private float NewInputSystemRotationDirection()
    {

        return input.actions["Move"].ReadValue<Vector2>().x;

    }

}