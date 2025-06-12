using System.Collections.Generic;
using UnityEngine;

public class SimpleResourceProvider : IResourceProvider
{
    private readonly List<IResource> _resources = new List<IResource>();

    public void Register(IResource resource) => _resources.Add(resource);

    public void Unregister(IResource resource) => _resources.Remove(resource);

    public IResource GetClosestResource(Vector3 fromPosition)
    {
        IResource closest = null;
        float minDist = float.MaxValue;

        foreach (var res in _resources)
        {
            if (!res.IsAvailable || res.IsCollecting || res.IsReserved) continue;

            float dist = Vector3.Distance(fromPosition, res.Position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = res;
            }
        }

        if (closest != null)
        {
            closest.IsReserved = true;
        }

        return closest;
    }
}