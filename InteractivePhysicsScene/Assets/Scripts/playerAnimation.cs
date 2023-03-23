using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody player_rb;
    private Animator animator;

    public Vector3 player_firstPos;
    public Vector3 player_lastPos;
    public bool isGrounded;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // save first position
        player_firstPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // save last position
        player_lastPos = this.transform.position;

        // update the player's speed
        speed = player_rb.velocity.magnitude;

        // if y-value didnt change, means player isGrounded
        // this is to not allow double jumps
        if (player_lastPos.y == player_firstPos.y)
        {
            isGrounded = true;
        }
    }

    // FixedUpdate is called after update
    void FixedUpdate()
    {
        // if x and z value is different from previous value, means player is moving
        if (player_lastPos.x != player_firstPos.x || player_lastPos.z != player_firstPos.z)
        {
            // set isMoving to true 
            animator.SetBool("isMoving", true);
            animator.SetFloat("speed", speed);
        }
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetFloat("speed", 0);
        }

        // if y-value is different from previous value, means player is jumping
        if (player_lastPos.y != player_firstPos.y)
        {
            animator.SetBool("isJumping", true);
            animator.SetFloat("speed", 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetFloat("speed", speed);
        }

        // reset the first position
        player_firstPos = player_lastPos;
    }
}
