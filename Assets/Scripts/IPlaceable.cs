using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaceable
{
    public GameObject PlaceObject { get; }
    public Tile CurrentTile { get; }
    public void SetTile(Tile tile);
}
