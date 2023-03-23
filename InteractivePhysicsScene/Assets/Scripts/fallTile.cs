using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTile : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	{
		// if player collides with tile, destory that tile after 0.5seconds
		if (collision.gameObject.tag == "player")
		{
			Destroy(gameObject, 0.5f);
		}
	}
}
