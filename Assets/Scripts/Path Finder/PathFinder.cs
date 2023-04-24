using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PathFinder
{
    public List<PathNode> finalPath = new();
    private PathNode _startNode, _currentNode, _targetNode;
    private Dictionary<Tile, PathNode> pathDictionary = new();
    
    public PathFinder()
    {
        foreach (var tile in Grid.TileBase)
        {
            pathDictionary.Add(tile, new PathNode(tile));
        }
    }

    public void FindPath(Tile startTile, Tile targetTile)
    {
        var openSet = new List<PathNode>();
        var closedSet = new HashSet<PathNode> ();
        
        _startNode = pathDictionary[startTile];
        _targetNode = pathDictionary[targetTile];
        
        openSet.Add(_startNode);

        while (openSet.Count > 0)
        {
            _currentNode = openSet[0];
            for (var i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].TotalCost < _currentNode.TotalCost || openSet[i].TotalCost == _currentNode.TotalCost && openSet[i].heuristicCost < _currentNode.heuristicCost)
                {
                    _currentNode = openSet[i];
                }
            }

            openSet.Remove(_currentNode);
            closedSet.Add(_currentNode);

            var neighborTiles = Grid.GetNeighborTiles(_currentNode.Tile);

            foreach (var n in neighborTiles)
            {
                var neighborNode = pathDictionary[n];
                if(!n.Enabled || closedSet.Contains(neighborNode)) continue;

                var currentCostToNeighbor = _currentNode.moveCost + GetDistance(_currentNode, neighborNode);
                if (currentCostToNeighbor < neighborNode.moveCost || !openSet.Contains(neighborNode))
                {
                    neighborNode.moveCost = currentCostToNeighbor;
                    neighborNode.heuristicCost = GetDistance(neighborNode, _targetNode);
                    neighborNode.Parent = _currentNode;
                    
                    if(!openSet.Contains(neighborNode)) 
                        openSet.Add(neighborNode);
                }
            }
            
            if (_currentNode == _targetNode)
            {
                GetFinalPath(_startNode, _targetNode);
                return;
            }
        }
    }

    void GetFinalPath(PathNode startNode, PathNode endNode) {
        
        var finalPath = new List<PathNode>();
        var currentNode = endNode;

        while (currentNode != startNode) 
        {
            finalPath.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        finalPath.Reverse();

        this.finalPath = finalPath;
    }
    
    private int GetDistance(PathNode current, PathNode end)
    {
       var column = Mathf.Abs(current.Tile.Column - end.Tile.Column);
       var row = Mathf.Abs(current.Tile.Row - end.Tile.Row);

       return column + row;
    }
}
