using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonMovement : MonoBehaviour
{
    Rigidbody cannon_rb;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        // add a force to the cannon to shoot it
        cannon_rb = GetComponent<Rigidbody>();
        cannon_rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        // automatically destroy the cannon after 1 second
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            // destroy cannon when it hits player
            Destroy(cannon_rb.gameObject);
        }
    }
}
