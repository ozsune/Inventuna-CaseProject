using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
   public static Tile[,] TileBase { get; private set; }
   public static int Height { get; private set; }
   public static int Width { get; private set; }
   public enum Directions {Up, Down, Left, Right}
   
   public Grid(GameObject tileObject ,int height, int width, float tileOffset, Vector3 spawnPosition, Transform parent)
   {
      Height = height;
      Width = width;
      
      GenerateGrid(tileObject, tileOffset, spawnPosition, parent);
   }

   public static Tile GetNeighborTile(Tile currentTile, Directions direction)
   {
      var up = currentTile.Column + 1;
      var down = currentTile.Column - 1;
      var left = currentTile.Row - 1;
      var right = currentTile.Row + 1;
      
      var neighborTile = new Dictionary<Directions, Tile>();
      if(up < Height)
         neighborTile.Add(Directions.Up, TileBase[up, currentTile.Row]);
      if(down >= 0)
         neighborTile.Add(Directions.Down, TileBase[down, currentTile.Row]);
      if(right < Width)
         neighborTile.Add(Directions.Right, TileBase[currentTile.Column, right]);
      if(left >= 0)
         neighborTile.Add(Directions.Left, TileBase[currentTile.Column, left]);
      
      return neighborTile[direction];
   }

   private void GenerateGrid(GameObject tileObject, float tileOffset, Vector3 spawnPosition, Transform parent)
   {
      TileBase = new Tile[Height,Width];

      var position = spawnPosition;
      for (var i = 0; i < Height; i++)
      {
         position.x = 0;
            
         for (var j = 0; j < Width; j++)
         {
            TileBase[i, j] = new Tile(Object.Instantiate(tileObject, position, Quaternion.identity, parent), i, j);
            
            position.x += tileOffset;
         }
         position.z += tileOffset;
      }
   }
}
