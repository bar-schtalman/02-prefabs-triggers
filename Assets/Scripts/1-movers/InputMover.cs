using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover : MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;
    float old_speed;
    private Transform objectTransform;
    private float x, y, z;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical  = new InputAction(type: InputActionType.Button);
    // float x = gameObject.transform.localScale.x;
    // float y = gameObject.transform.localScale.y;
    // float z = gameObject.transform.localScale.z;
    //Vector3 curr =  gameObject.transform.localScale;

    public void shrink(){
        transform.localScale = new Vector3(x/2,y/2,z);
    }
    
    public void grow(){
        transform.localScale = new Vector3(x,y,z);
    }

    void OnEnable()  {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()  {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }
    public void speed_up(){
        old_speed  = speed;
        speed *=3;
    }
    public void slow_down(){
        speed = old_speed;
    }
    void Start(){
        objectTransform = gameObject.transform;
        x = objectTransform.localScale.x;
        y = objectTransform.localScale.y;
        z = objectTransform.localScale.z;
    }

    void Update() {
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
