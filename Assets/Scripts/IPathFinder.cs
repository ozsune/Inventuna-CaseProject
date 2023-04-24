using System;
using System.Collections;
using UnityEngine;

public interface IPathFinder
{
    public event Action onPathComplete;
    public bool Move { get; set; }
    public IEnumerator MovePosition();
}
