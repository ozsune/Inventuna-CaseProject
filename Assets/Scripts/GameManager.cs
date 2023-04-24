using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalCompetedPaths;
    
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    [SerializeField] private GridGenerator gridGenerator;

    private List<Spawner> _spawners = new();
    
    void Awake()
    {
        gridGenerator.onGridCreated += StartNewGame;
    }
    
    public void StartNewGame()
    {
        _spawners.Clear();
        SpawnEntity(PlayerPrefab);
        SpawnEntity(EnemyPrefab);
    }
    
    private void SpawnEntity(GameObject spawn)
    {
        var spawner = new Spawner(spawn);
        _spawners.Add(spawner);
        
        spawner.Spawn(Grid.FindRandomAvailableTile());
        if (spawner.SpawnedObject.TryGetComponent(out IPathFinder pathFinder))
        {
            pathFinder.onPathComplete += DeSpawnEntity;
        }
    }

    private void DeSpawnEntity()
    {
        foreach (var s in _spawners) 
            s.DeSpawn();

        totalCompetedPaths++;
        StartNewGame();
    }
}
