using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

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

   public static IDictionary<Directions, Tile> GetNeighborTiles(Tile currentTile, Directions direction)
   {
      var up = currentTile.Column + 1;
      var down = currentTile.Column - 1;
      var left = currentTile.Row - 1;
      var right = currentTile.Row + 1;
      
      var neighborTiles = new Dictionary<Directions, Tile>();
      if(up < Height)
         neighborTiles.Add(Directions.Up, TileBase[up, currentTile.Row]);
      if(down >= 0)
         neighborTiles.Add(Directions.Down, TileBase[down, currentTile.Row]);
      if(right < Width)
         neighborTiles.Add(Directions.Right, TileBase[currentTile.Column, right]);
      if(left >= 0)
         neighborTiles.Add(Directions.Left, TileBase[currentTile.Column, left]);
      
      return neighborTiles;
   }

   public static Tile FindRandomTile()
   {
      Tile selectedTile;
      do selectedTile = TileBase[Random.Range(0, Height), Random.Range(0, Width)];
      while (selectedTile.Occupied);
      return selectedTile;
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
