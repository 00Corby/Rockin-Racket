using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawnItem;

    public float frequency;

    public float initialSpeed;

    float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastSpawnedTime + frequency)
        {
            Spawn();
            lastSpawnedTime = Time.time;
        }
    }


    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);
        newSpawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;
    }
}
