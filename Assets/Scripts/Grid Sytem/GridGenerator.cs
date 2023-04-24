using System;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public event Action onGridCreated;
    
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int height, width;
    [SerializeField] private float offset;
    [SerializeField] private Vector3 generatingPosition;
    
    public void Generate(int height, int width)
    {
        this.height = height;
        this.width = width;
        
        var gridRoot = new GameObject("Grid");
        var grid = new Grid(tilePrefab, height, width, gridRoot.transform);
        
        onGridCreated?.Invoke();
    }
}
