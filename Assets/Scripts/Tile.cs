using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tile
{
    private bool _occupied;
    public bool Occupied 
    { 
        get => _occupied;
        private set
        {
            _occupied = value;
            var occupied = "-(OCCUPIED)";
            if (_occupied)
                TileGameObject.name += occupied;
            else TileGameObject.name = _tileName;
        } 
    }
    public GameObject TileGameObject { get; }
    public int Column { get; }
    public int Row { get; }
    public Vector3 TilePosition { get; }

    private IPlaceable _placeable;
    private IPlaceable PlaceableObject
    {
        get => _placeable;
        set
        {
            _placeable = value;
            Occupied = _placeable != null;
        }
    }

    private string _tileName;
    
    public Tile(GameObject gameObject, int column, int row)
    {
        Column = column;
        Row = row;
        
        TileGameObject = gameObject;
        _tileName = "Tile " + column + " : " + row;
        TileGameObject.name = _tileName;
        TilePosition = TileGameObject.transform.position;
    }

    public Tile Place(IPlaceable targetObject)
    {
        PlaceableObject = targetObject;
        return this;
    }
    
    public Tile Remove(IPlaceable targetObject)
    {
        PlaceableObject = null;
        return this;
    }
}
