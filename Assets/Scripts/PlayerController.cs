using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlaceable, IPathFinder
{
    public event Action onPathComplete;
    public GameObject PlaceObject { get; private set; }
    public Tile CurrentTile { get; private set; }
    public Tile DestinationTile { get; private set; }
    public ObjectPlacer Placer { get; private set; }

    void Awake()
    {
        PlaceObject = gameObject;
        Placer = new ObjectPlacer(this);
    }

    private void Start()
    {
        StartCoroutine(MovePosition());
    }

    public void SetTile(Tile tile)
    {
        CurrentTile = tile;
    }

    public IEnumerator MovePosition()
    {
        DestinationTile = FindObjectOfType<EnemyController>().CurrentTile;
        
        var path = new PathFinder(CurrentTile, DestinationTile);
        var pathIndex = 0;
        
        path.FindHeuristicPath();
        
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            
            Placer.Place(path.heuristicPath[pathIndex], path.heuristicPath[pathIndex].Enabled);
            
            if(CurrentTile == path.heuristicPath[^1])
                onPathComplete?.Invoke();
            else
                pathIndex++;
        }
    }
    
    
}
