using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IPlaceable
{
    private IPlaceable _placeable;
    public IPlaceable PlaceableType
    {
        get => this;
        private set => _placeable = value;
    }
    
    private Tile _tile;
    public Tile CurrentTile
    {
        get => _tile;
        set
        {
            _tile = value.Place(PlaceableType);
            SetPosition();
        }
    }
    
    private void SetPosition()
    {
        transform.position = CurrentTile.TilePosition;
        transform.parent = CurrentTile.TileGameObject.transform;
    }
    
}
