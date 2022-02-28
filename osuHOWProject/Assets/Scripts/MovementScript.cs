using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;
    public Rigidbody playerRb;
    public float speed = 12f;
    public float gravity = -9.0f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool OnGround;
    bool KeyCollected;

    void Start()
    {
        KeyCollected = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (OnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            KeyCollected = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Door") && KeyCollected)
        {
            SceneManager.LoadScene("WinScene");
            //Debug.Log("Touched");
        }
    }
}
