using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer
{
   public IPlaceable Placeable { get; }
   public ObjectPlacer(IPlaceable placeableType)
   {
      Placeable = placeableType;
   }
   
   public void Place(Tile placingTile, bool placeCondition)
   {
      if (placeCondition)
      {
         Placeable.CurrentTile?.Remove();
         placingTile.Place(Placeable);
      }
      else
      {
         Debug.Log("Tile is not available.");
      }
   }
}
