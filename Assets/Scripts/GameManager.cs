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
        _spawner = new Spawn(spawn, Grid.FindRandomAvailableTile());
    }
}
