using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCannon : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    public Transform cannonSpawnPoint;
    public GameObject cannonPrefab;
    [SerializeField] float spawnTime;
    [SerializeField] float distance;

    // Start is called before the first frame update
    void Start()
    {
        //coroutine allows spreading tasks across several frames
        // start the coroutine
        StartCoroutine(Cannon());
    }

    // Update is called once per frame
    private void SpawnCannon()
    {
        // if the player is within a certain distance from the cannon
        // and if the player is still infront of the cannon
        // (haven't gone pass the cannon z-position )
        if(playerTransform.position.z + distance >= cannonSpawnPoint.position.z &&
           playerTransform.position.z <= cannonSpawnPoint.position.z)
        {
            // create cannons
            Instantiate(cannonPrefab, cannonSpawnPoint.position, cannonSpawnPoint.rotation);
        }
    }

    IEnumerator Cannon()
    {
        while(true)
        {
            // calls SpawnCannon after a delay
            yield return new WaitForSeconds(spawnTime);
            SpawnCannon();
        }
    }
}
