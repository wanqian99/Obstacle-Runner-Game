using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    Vector3 offset;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //offset how far the camera should be behind the player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
