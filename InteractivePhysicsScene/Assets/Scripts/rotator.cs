using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        // rotate anticlockwise (-speed)
        transform.Rotate(-speed * Time.deltaTime / 0.01f, 0f, 0f, Space.Self);
    }
}
