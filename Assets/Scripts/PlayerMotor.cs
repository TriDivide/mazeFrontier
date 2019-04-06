using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {


    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 tilt = Vector3.zero;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 movementVelocity) {
        velocity = movementVelocity;
    }

    public void Rotate(Vector3 rotationVelocity) {
        rotation = rotationVelocity;
    }

    public void RotateCamera(Vector3 rotationVelocity) {
        tilt = rotationVelocity;
    }

    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }

    private void PerformRotation() {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null) {
            cam.transform.Rotate(-tilt);
        }
    }

    private void PerformMovement() {
        if (velocity != Vector3.zero) {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}

