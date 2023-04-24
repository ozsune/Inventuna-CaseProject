using UnityEngine;
using Object = UnityEngine.Object;

public class Spawner
{
    public GameObject SpawnedObject { get; private set; }

    private readonly GameObject _spawnPrefab;
    private ObjectPlacer _placer;
    private IPlaceable _placeable;

    public Spawner(GameObject spawnPrefab)
    {
        _spawnPrefab = spawnPrefab;
    }

    public void Spawn(Tile tile)
    {
        SpawnedObject = Object.Instantiate(_spawnPrefab);
        _placeable = SpawnedObject.GetComponent<IPlaceable>();    

        _placer = new ObjectPlacer(_placeable);
        _placer.Place(tile, !tile.Occupied);
    }

    public void DeSpawn()
    {
        Object.Destroy(SpawnedObject);
        _placeable = null;
    }
}
