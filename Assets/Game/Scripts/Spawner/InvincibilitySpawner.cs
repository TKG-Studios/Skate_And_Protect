using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilitySpawner : Spawner
{
    public GameObject invincibility;
    public static InvincibilitySpawner instance;
    public override void SpawnItem(GameObject itemToSpawn)
    {
        base.SpawnItem(invincibility);
    }

}
