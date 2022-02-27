using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 8.0f;
    public Camera followCam;

    private Rigidbody playerRb;
    private Vector3 camPos;
    private float spdModeifier = 1;
    bool OnGround;

    private bool key;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        camPos = followCam.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hInput, 0 ,vInput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
        playerRb.MoveRotation(targetRotation);

            if (Input.GetKey(KeyCode.Space) && OnGround == true)
        {
            playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);

            OnGround = false;
        }
    }

    void LateUpdate()
    {
        followCam.transform.position = playerRb.position + camPos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {

        }
    }
}
