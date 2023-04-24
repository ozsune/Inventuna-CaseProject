using System;
using System.Collections;

public interface IPathFinder
{
    public event Action onPathComplete;
    public event Action onPathFail;
    public bool Move { get; set; }
    public float MovementDelay { get; set; }
    public IEnumerator MovePosition();
}
