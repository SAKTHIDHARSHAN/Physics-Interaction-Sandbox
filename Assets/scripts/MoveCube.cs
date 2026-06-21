using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(
            moveX * moveForce,
            rb.velocity.y,
            moveZ * moveForce
        );

        rb.velocity = velocity;

        if (moveX != 0 || moveZ != 0)
        {
            Vector3 direction = new Vector3(moveX, 0f, moveZ);

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                0.2f
            );
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Target Hit");

            gameManager.AddScore(1);

            Destroy(collision.gameObject);
        }
    }
}