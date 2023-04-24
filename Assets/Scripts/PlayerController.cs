using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlaceable, IPathFinder
{
    public event Action onPathComplete;
    public event Action onPathFail;
    [field:SerializeField] public float MovementDelay { get; set; }
    public GameObject PlaceObject { get; private set; }
    public Tile CurrentTile { get; private set; }
    public Tile DestinationTile { get; private set; }
    public ObjectPlacer Placer { get; private set; }
    
    public bool Move
    {
        get => _move;
        set
        {
            _move = value;
            if(_move)
                StartCoroutine(MovePosition());
        }
    }
    
    private bool _move;

    void Awake()
    {
        PlaceObject = gameObject;
        Placer = new ObjectPlacer(this);
    }
    
    public void SetTile(Tile tile)
    {
        CurrentTile = tile;
    }

    public IEnumerator MovePosition()
    {
        yield return new WaitForSeconds(1f);

        DestinationTile = FindObjectOfType<EnemyController>().CurrentTile;
        
        var path = new PathFinder();
        var pathIndex = 0;
        path.FindPath(CurrentTile, DestinationTile);
        
        while (CurrentTile != DestinationTile)
        {
            yield return new WaitForSeconds(MovementDelay);

            if (path.finalPath.Count == 0)
            {
                onPathFail?.Invoke();
                break;
            }
            
            Placer.Place(path.finalPath[pathIndex].Tile);
            pathIndex++;
                
            if (CurrentTile == path.finalPath[^1].Tile)
            {
                yield return new WaitForSeconds(MovementDelay);

                onPathComplete?.Invoke();
                CurrentTile.Enabled = false;
                Move = false;
                break;
            }
        }
    }
    
    
}
