using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    float maxAngle = 30.0f;
    float speed = 2.5f;
    [SerializeField] bool goRight;

    // Update is called once per frame
    void Update()
    {
        // pendulum rotate right first
        if (goRight)
        {
            // calculate the angle to rotate
            float angle = maxAngle * Mathf.Sin(Time.time * speed);
            // use localRotation for the rotation to be relative to the parent
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        // pendulum rotate left first
        else
        {
            // calculate the angle to rotate
            float angle = maxAngle * Mathf.Sin(Time.time * speed);
            // use localRotation for the rotation to be relative to the parent
            transform.localRotation = Quaternion.Euler(0, 0, -angle);
        }
            
    }
}
