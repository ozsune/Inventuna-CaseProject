using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalCompetedPaths;
    
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    [SerializeField] private GridGenerator gridGenerator;

    private HashSet<Spawner> _spawners = new();
    
    void Awake()
    {
        gridGenerator.onGridCreated += StartNewGame;
    }
    
    public void StartNewGame()
    {
        _spawners.Clear();
        
        SpawnEntity(EnemyPrefab);
        SpawnEntity(PlayerPrefab);
    }
    
    private void SpawnEntity(GameObject spawn)
    {
        var spawner = new Spawner(spawn);
        
        _spawners.Add(spawner);
        spawner.Spawn(Grid.FindRandomAvailableTile());

        if (spawner.SpawnedObject.TryGetComponent(out IPathFinder pathFinder))
        {
            pathFinder.Move = true;
            pathFinder.onPathComplete += DeSpawnEntity;
        }
    }

    private void DeSpawnEntity()
    {
        foreach (var s in _spawners) 
            s.DeSpawn();

        totalCompetedPaths++;
        Invoke(nameof(StartNewGame), 1);
    }
}
