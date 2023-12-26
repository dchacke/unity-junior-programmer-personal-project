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
    public float highestY;

    // Start is called before the first frame update
    void Start()
    {
        highestY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ConstrainMovement();
        TrackHighestY();
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

    private float TrackHighestY()
    {
        highestY = Mathf.Max(highestY, transform.position.y);

        return highestY;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Vulnerability"))
        {
            rb.AddForce(Vector3.up * verticalSpeed, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Vulnerability"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game over");
        }
    }
}
