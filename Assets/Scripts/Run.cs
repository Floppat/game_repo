using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Run : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 50f;
    Vector3 direction;
    Vector3 lastDirection;
    int tick = 0;
    [SerializeField] float jumpForce = 10f;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (!isGrounded)
        {
            Debug.Log(direction);
            Debug.Log(lastDirection);
            Debug.Log(direction - lastDirection);
            direction = Vector3.Lerp(lastDirection, direction, 1f/10f);
        }
        if (tick == 10)
        {
            tick = 0;
            lastDirection = direction;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        tick++;
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }
    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}
