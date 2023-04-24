using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour, IPlaceable
{
    public GameObject PlaceObject { get; private set; }
    public Tile CurrentTile { get; private set; }
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
        Debug.Log(CurrentTile.TileObject.name);
        var path = new PathFinder(CurrentTile, FindObjectOfType<EnemyController>().CurrentTile);
        path.FindShortestPath();
        var pathIndex = 0;
        
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            Placer.Place(path.heuristicPath[pathIndex], path.heuristicPath[pathIndex].Enabled);
            pathIndex++;

        }
    }
    
    
}
