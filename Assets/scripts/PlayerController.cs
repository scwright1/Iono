using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    [Range (1f,10f)]
    public float movementSpeed = 6f;
    [Range (1f,10f)]
    public float rotationSpeed = 6f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {

        float linearMovement = Input.GetAxis("Vertical");
        float directionalRotation = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(directionalRotation, 0f, linearMovement);
        rb.velocity = movement * movementSpeed;
        if(rb.velocity.magnitude >= 0.1f) {
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rb.velocity), rb.velocity.magnitude * rotationSpeed * Time.deltaTime));
        }
    }
}
