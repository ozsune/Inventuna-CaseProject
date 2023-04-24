using UnityEngine;

public class Tile
{
    public GameObject TileObject { get; }
    public int Column { get; }
    public int Row { get; }
    public Vector3 TilePosition { get; }
    
    private bool _occupied;
    public bool Occupied 
    { 
        get => _occupied;
        private set
        {
            _occupied = value;
            var occupied = "-(OCCUPIED)";
            if (_occupied)
                TileObject.name += occupied;
            else TileObject.name = _tileName;
        } 
    }

    private bool _enabled;
    public bool Enabled 
    { 
        get => _enabled; 
        set
        {
            _enabled = value;
            var disabled = "-(DISABLED)";
            if (_occupied)
                TileObject.name += disabled;
            else TileObject.name = _tileName;
        } 
    }
    
    private IPlaceable Placeable;
    private string _tileName;
    
    public Tile(GameObject tileObject, int column, int row)
    {
        Column = column;
        Row = row;
        
        _tileName = "Tile " + column + " : " + row;

        TileObject = tileObject;
        TileObject.name = _tileName;
        TilePosition = TileObject.transform.position;
        Enabled = true;
    }

    public void Place(IPlaceable placeable)
    {
        Placeable = placeable;
        Placeable.SetTile(this);
        
        Placeable.PlaceObject.transform.position = TilePosition;
        Placeable.PlaceObject.transform.parent = TileObject.transform;
        
        Occupied = true;
    }
    
    public void Remove()
    {
        Placeable = null;
        Occupied = false;
        
    }
}
