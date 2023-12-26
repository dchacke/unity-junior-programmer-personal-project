using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < pc.highestY - 10)
        {
            if (gameObject.CompareTag("Player"))
            {
                Debug.Log("Game over");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
