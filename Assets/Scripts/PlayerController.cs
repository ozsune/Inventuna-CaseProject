using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour, IPlaceable
{
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
    
    private IEnumerator MovePosition()
    {
        DestinationTile = FindObjectOfType<EnemyController>().CurrentTile;
        
        var path = new PathFinder(CurrentTile, DestinationTile);
        var pathIndex = 0;
        
        path.FindHeuristicPath();
        
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            Placer.Place(path.heuristicPath[pathIndex], path.heuristicPath[pathIndex].Enabled);
            
            if(pathIndex < path.heuristicPath.Count - 1)
                pathIndex++;
        }
    }
    
    
}
