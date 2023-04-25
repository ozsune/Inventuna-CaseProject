using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int totalCompetedPaths;

    [SerializeField] private GameObject gridCreatorUI, gameOverUI;
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    [SerializeField] private GridGenerator gridGenerator;

    private HashSet<Spawner> _spawners = new();
    private CameraController _camera;
    void Awake()
    {
        totalCompetedPaths = 0;
        _camera = Camera.main.GetComponent<CameraController>();
        
        gridCreatorUI.SetActive(true);
        gameOverUI.SetActive(false);

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
            _camera.SetTarget();

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
