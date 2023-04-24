using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathFinder
{
    private Tile _destinationTile;
    private Tile _currentTile;

    public List<Tile> heuristicPath = new();
    public PathFinder(Tile startTile, Tile destinationTile)
    {
        _currentTile = startTile;
        _destinationTile = destinationTile;
    }
    
    public void FindHeuristicPath()
    {
        heuristicPath.Add( _currentTile);
        
        while (_currentTile != _destinationTile)
        {
            var neighborTiles = Grid.GetNeighborTiles(_currentTile);

            foreach (var t in neighborTiles)
            {
                var neighbor = neighborTiles[Random.Range(0, neighborTiles.Count)];
                if (GetDistance(neighbor, _destinationTile) < GetDistance(_currentTile, _destinationTile))
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
