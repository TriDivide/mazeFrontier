using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float mouseSpeed = 3f;

    private PlayerMotor motor;

    private void Start() {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update() {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMovement;
        Vector3 moveVertical = transform.forward * zMovement;


        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);


        //Calculate rotation as 3D vector(turning) 

        float yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRotation, 0f) * mouseSpeed;

        motor.Rotate(rotation);


        // Calculate Camera rotation as 3D vector(up down)
        float xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 tilt = new Vector3(xRotation, 0f, 0f) * mouseSpeed;

        motor.RotateCamera(tilt);
    }
}
