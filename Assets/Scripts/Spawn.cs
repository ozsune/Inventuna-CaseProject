using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Spawn
{
    public Spawn(GameObject spawnPrefab, Tile tile, Transform parent)
    {
        if (spawnPrefab.TryGetComponent(out IPlaceable placeable))
        {
            var spawn = Object.Instantiate(spawnPrefab);
            spawn.GetComponent<IPlaceable>().CurrentTile = tile;
        }
        else Debug.LogError("Spawned Object is not Placeable!");
    }
}
