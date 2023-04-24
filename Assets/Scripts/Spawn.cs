using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Spawn
{
    public Spawn(GameObject spawnPrefab, Tile tile)
    {
        if (spawnPrefab.TryGetComponent(out IPlaceable placeable))
        {
            var spawn = Object.Instantiate(spawnPrefab);
            
            var placer = new ObjectPlacer(spawn.GetComponent<IPlaceable>());
            Debug.Log(placer.Placeable.PlaceObject.name);
            placer.Place(tile, !tile.Occupied);
        }
        else Debug.LogError("Spawned Object is not Placeable!");
    }
}
