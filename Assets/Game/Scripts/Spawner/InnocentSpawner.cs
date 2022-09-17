using UnityEngine;

public class InnocentSpawner : Spawner
{
    public GameObject innocent;

    private int spawnIntervalController;

    // Update is called once per frame
    private void Update()
    {

        if (GameManager.instance.currentState == GameManager.GameStates.GameActive)
        {
            if (timeToSpawn > 0)
            {
                timeToSpawn -= Time.deltaTime;
                if (timeToSpawn <= 0)
                {
                    spawnIntervalController = Random.Range(1, 5);
                    spawnInterval = spawnIntervalController;
                    timeToSpawn = spawnInterval;
                    SpawnItem(innocent);
                }
            }
        }
    }
}