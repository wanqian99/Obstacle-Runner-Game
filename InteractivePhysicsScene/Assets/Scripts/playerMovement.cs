using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody player_rb;
    public playerAnimation playerAnimation;

    [SerializeField] AudioSource audioSource;

    [SerializeField] float movementSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player falls, reload the scene
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // FixedUpdate is used for physics movement
    void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");

        //calculate the direction to move
        Vector3 direction = new Vector3(xAxis, 0, zAxis);
        // normalize direction to make sure it has a magnitude of 1
        direction.Normalize();

        // move player based on keys (up, down, left, right)
        //Time.deltaTime is used for frame rate independence
        player_rb.AddForce(direction * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);

        if (direction != Vector3.zero)
        {
            // create rotation angle to look at direction
            // set forward direction to movement direction, set up-direction to y-axis 
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            // rotate from current rotation to direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }

        // only allow jumping when player isGrounded
        if (playerAnimation.isGrounded && Input.GetButtonDown("Jump"))
        {
            audioSource.Play();
            player_rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            playerAnimation.isGrounded = false;
        }

        // limit player's max speed
        if (player_rb.velocity.magnitude > maxSpeed)
        {
            player_rb.velocity = Vector3.ClampMagnitude(player_rb.velocity, maxSpeed);
        }
    }

    //check if player is on the ground
    //(for player to be able to jump on rotating plates)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rotatingPlates")
        {
            playerAnimation.isGrounded = true;
        }
    }

    //check if player is NOT on the ground
    //(for player to NOT be able to jump when NOT on rotating plates)
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "rotatingPlates")
        {
            playerAnimation.isGrounded = false;
        }
    }
}
