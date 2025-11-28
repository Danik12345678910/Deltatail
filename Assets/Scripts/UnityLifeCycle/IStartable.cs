using UnityEngine;

public interface IStartable
{
    int Priority { get; }
    void Start();
}
