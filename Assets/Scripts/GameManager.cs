using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalCompetedPaths;

    [SerializeField] private GameObject gridCreatorUI, gameOverUI;
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    [SerializeField] private GridGenerator gridGenerator;

    private HashSet<Spawner> _spawners = new();
    
    void Awake()
    {
        totalCompetedPaths = 0;

        gridCreatorUI.SetActive(true);
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
            pathFinder.onPathFail += GameOver;
        }
    }

    private void DeSpawnEntity()
    {
        foreach (var s in _spawners) 
            s.DeSpawn();

        totalCompetedPaths++;
        Invoke(nameof(StartNewGame), 1);
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
