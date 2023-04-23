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
        Placer = new ObjectPlacer(this);

        PlaceObject = gameObject;
        StartCoroutine(MovePosition());
    }

    public void SetTile(Tile tile)
    {
        CurrentTile = tile;
    }
    
    private IEnumerator MovePosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            var direction = (Grid.Directions)Random.Range(0, 4);
            var neighborTiles = Grid.GetNeighborTiles(CurrentTile, direction);

            if(!neighborTiles.ContainsKey(direction)) continue;

            Placer.Place(neighborTiles[direction], neighborTiles[direction].Enabled);
        }
    }
    
    
}
