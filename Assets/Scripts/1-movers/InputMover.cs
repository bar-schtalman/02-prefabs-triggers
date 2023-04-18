using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] private float speed = 10f;
    private float oldSpeed;
    private Transform objectTransform;
    private float x, y, z;

    [SerializeField] private InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] private InputAction moveVertical = new InputAction(type: InputActionType.Button);

    public void Shrink()
    {
        transform.localScale = new Vector3(x / 2, y / 2, z);
    }

    public void Grow()
    {
        transform.localScale = new Vector3(x, y, z);
    }

    public void SpeedUp()
    {
        oldSpeed = speed;
        speed *= 3;
    }

    public void SlowDown()
    {
        speed = oldSpeed;
    }

    private void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    private void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    private void Start()
    {
        objectTransform = transform;
        x = objectTransform.localScale.x;
        y = objectTransform.localScale.y;
        z = objectTransform.localScale.z;
    }

    private void Update()
    {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
        //transform.Translate(movementVector);
        // NOTE: "Translate(movementVector)" uses relative coordinates - 
        //       it moves the object in the coordinate system of the object itself.
        // In contrast, "transform.position += movementVector" would use absolute coordinates -
        //       it moves the object in the coordinate system of the world.
        // It makes a difference only if the object is rotated.
    }
}
