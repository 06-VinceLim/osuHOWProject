using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    bool OnGround;

    void Start()
    {
        OnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            SceneManager.LoadScene("WinScene");
            //Debug.Log("Touched");
        }
    }
}
