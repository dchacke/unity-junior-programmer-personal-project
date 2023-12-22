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
        rb.AddForce(Vector3.up * verticalSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right * horizontalInput * horizontalSpeed);
    }
}
