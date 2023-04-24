using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        var grid = new Grid(tilePrefab, height, width, offset, generatingPosition, gridRoot.transform);
        
        onGridCreated?.Invoke();
    }
}
