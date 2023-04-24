using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab, EnemyPrefab;
    [SerializeField] private GridGenerator gridGenerator;

    private Spawn _spawner;
    
    void Awake()
    {
        gridGenerator.onGridCreated += StartNewGame;
    }
    
    public void StartNewGame()
    {
        SpawnEntity(PlayerPrefab);
        SpawnEntity(EnemyPrefab);
    }
    
    private void SpawnEntity(GameObject spawn)
    {
        _spawner = new Spawn(spawn, Grid.FindRandomAvailableTile());
    }
}
