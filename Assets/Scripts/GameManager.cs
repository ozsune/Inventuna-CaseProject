using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    private Spawn _spawner;
    void Start()
    {
        SpawnEntity(PlayerPrefab);
        SpawnEntity(EnemyPrefab);
    }

    private void SpawnEntity(GameObject spawn)
    {
        Tile selectedTile;
        do selectedTile = Grid.TileBase[Random.Range(0, Grid.Height), Random.Range(0, Grid.Width)];
        while (selectedTile.Occupied);
        
        _spawner = new Spawn(spawn, selectedTile, null);
    }
}
