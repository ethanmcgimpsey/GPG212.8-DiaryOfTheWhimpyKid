using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float objectDuration;
    public float spawnTimer, maxTimer;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = maxTimer;// Reset the timer
        }
    }

    void SpawnObject()
    {
        // Instantiate the object prefab
        GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

        // Destroy the object after a certain duration
        Destroy(newObject, objectDuration);
    }
}
