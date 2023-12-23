using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float horizontalSpeed;
    public float verticalSpeed;

    public int leftBound;
    public int rightBound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ConstrainMovement();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
    }

    private void ConstrainMovement()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBound, rightBound),
            transform.position.y,
            transform.position.z
        );
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            rb.AddForce(Vector3.up * verticalSpeed, ForceMode.Impulse);
        }
    }
}
