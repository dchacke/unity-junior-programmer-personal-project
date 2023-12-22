using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float horizontalSpeed;
    public float verticalSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * horizontalInput * horizontalSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            rb.AddForce(Vector3.up * verticalSpeed, ForceMode.Impulse);
        }
    }
}
