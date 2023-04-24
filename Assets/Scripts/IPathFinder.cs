using System;
using System.Collections;
using UnityEngine;

public interface IPathFinder
{
    public event Action onPathComplete;
    public IEnumerator MovePosition();
}
