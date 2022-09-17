using SimpleAudioManager;
using UnityEngine;

public class HazardSpawner : Spawner
{
    public GameObject hazard;
    public GameObject healthDrop;

    private int determineDrop;
    private float spawnIntervalController;

    private void Update()
    {
        if (GameManager.instance.currentState == GameManager.GameStates.GameActive)
        {
            if (timeToSpawn > 0)
            {
                timeToSpawn -= Time.deltaTime;

                if (timeToSpawn <= 0)
                {
                    spawnIntervalController = Random.Range(0.8f, 1.5f);
                    spawnInterval = spawnIntervalController;
                    timeToSpawn = spawnInterval;
                    AudioManager.instance.HazardDrop();
                    if (timeToSpawn == spawnInterval)
                    {
                        determineDrop = Random.Range(0, 7);
                    }

                    if (determineDrop >= 2)
                    {
                        GetComponentInChildren<SpriteRenderer>().color = Color.red;
                        SpawnItem(hazard);
                    }
                    else if (determineDrop <= 1 && PlayerHealth.instance.health < PlayerHealth.instance.maxHealth)
                    {
                        GetComponentInChildren<SpriteRenderer>().color = Color.green;
                        SpawnItem(healthDrop);
                    }
                    else
                    {
                        GetComponentInChildren<SpriteRenderer>().color = Color.red;
                        SpawnItem(hazard);
                    }
                }
            }
        }
    }
}