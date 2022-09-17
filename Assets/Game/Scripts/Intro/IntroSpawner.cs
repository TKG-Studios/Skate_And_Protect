using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSpawner : Spawner
{
    public GameObject playerCharacter;


    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn > 0)
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                spawnInterval = 10f;
                timeToSpawn = spawnInterval;
                SpawnItem(playerCharacter);
            }
        }
    }
}
