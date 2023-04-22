using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int height, width;
    [SerializeField] private float offset;
    [SerializeField] private Vector3 generatingPosition;
    
    public Grid grid;
    private GameObject player;
    private void Awake()
    {
        var gridRoot = new GameObject("Grid");
        grid = new Grid(tilePrefab, height, width, offset, generatingPosition, gridRoot.transform);
    }
}
