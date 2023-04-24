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
      Placeable.CurrentTile?.Remove();
      placingTile.Place(Placeable);
   }
}
