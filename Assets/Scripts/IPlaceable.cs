using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaceable
{ 
    public IPlaceable PlaceableType{ get; }
    public Tile CurrentTile { get; set; }
}
