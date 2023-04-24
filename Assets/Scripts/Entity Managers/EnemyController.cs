using UnityEngine;

public class EnemyController : MonoBehaviour, IPlaceable
{
    public GameObject PlaceObject { get; private set; }
    public Tile CurrentTile { get; set; }
    public ObjectPlacer Placer { get; private set; }

    private void Awake()
    {
        Placer = new ObjectPlacer(this);

        PlaceObject = gameObject;
    }
    
    public void SetTile(Tile tile)
    {
        CurrentTile = tile;
    }

}
