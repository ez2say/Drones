using UnityEngine;

public interface IResourceProvider
{
    IResource GetClosestResource(Vector3 fromPosition);
    void Register(IResource resource);
    void Unregister(IResource resource);
}