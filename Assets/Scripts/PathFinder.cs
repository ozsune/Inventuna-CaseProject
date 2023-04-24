using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathFinder
{
    private Tile _endTile;
    private Tile _currentTile;

    public List<Tile> heuristicPath = new();
    public PathFinder(Tile startTile, Tile endTile)
    {
        _currentTile = startTile;
        _endTile = endTile;
    }
    
    public void FindShortestPath()
    {
        heuristicPath.Add( _currentTile);
        
        while (_currentTile != _endTile)
        {
            Debug.Log(_currentTile.TileObject.name);
            var neighborTiles = Grid.GetNeighborTiles(_currentTile);

            Tile neighbor = null;
            foreach (var t in neighborTiles)
            {
                neighbor = neighborTiles[Random.Range(0, neighborTiles.Count)];
                if (GetDistance(neighbor, _endTile) < GetDistance(_currentTile, _endTile))
                    _currentTile = neighbor;
            }
            
            heuristicPath.Add(_currentTile);
        }
    }

    private int GetDistance(Tile current, Tile end)
    {
       var column = Mathf.Abs(current.Column - end.Column);
       var row = Mathf.Abs(current.Row - end.Row);

       return column + row;
    }
}
