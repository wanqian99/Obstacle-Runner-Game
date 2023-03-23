using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBlock : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] float speed;
    [SerializeField] bool goRight;
    public float offset;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        transform.position += Vector3.right * offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (goRight)
        {
            // move block right if x-value is less than startPos.x + distance to move
            if (transform.position.x < startPos.x + distance)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                // set to false to move left next
                goRight = false;
            }
        }
        else
        {
            // move block left if x-value is more than startPos.x
            if (transform.position.x > startPos.x)
            {
                transform.position -= Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                // set to true to move right next
                goRight = true;
            }
        }
    }
}
