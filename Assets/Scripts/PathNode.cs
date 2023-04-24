using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public Tile Tile { get; }
    public bool Moveable { get; }
    public int TotalCost => moveCost + heuristicCost;
    
    public PathNode Parent;

    public int moveCost;
    public int heuristicCost;

    public PathNode(Tile tile)
    {
        Tile = tile;
        Moveable = tile.Enabled;
    }
}
