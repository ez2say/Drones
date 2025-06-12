using UnityEngine;

public interface IBase
{
    Vector3 Position { get; }
    int ResourceCount { get; }
    void AddResource();
}

