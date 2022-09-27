using UnityEngine;

public class Spawner : MonoBehaviour
{
    [HideInInspector]
    public float timeToSpawn;

    public float spawnInterval;

    private void Start()
    {
        timeToSpawn = spawnInterval;
    }

    public virtual void SpawnItem(GameObject itemToSpawn)
    {
        Instantiate(itemToSpawn, transform.position, Quaternion.identity);
    }
}