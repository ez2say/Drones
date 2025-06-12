using UnityEngine;

public class DroneSpawner : IDroneSpawner
{
    private readonly IDroneFactory _factory;
    private readonly IResourceProvider _resourceProvider;

    public DroneSpawner(IDroneFactory factory, IResourceProvider resourceProvider)
    {
        _factory = factory;
        _resourceProvider = resourceProvider;
    }

    public void SpawnDrones(IBase blueBase, IBase redBase, int dronesPerFaction)
    {
        for (int i = 0; i < dronesPerFaction; i++)
        {
            CreateDroneAtBase(blueBase);
            CreateDroneAtBase(redBase);
        }
    }

    private void CreateDroneAtBase(IBase homeBase)
    {
        IDrone drone = _factory.Create(homeBase);
        // Больше не нужно явно вызывать SetResourceProvider,
        // так как он устанавливается в Initialize

        if (drone is MonoBehaviour mono)
        {
            mono.transform.position = homeBase.Position + Random.insideUnitSphere * 2f;
        }
    }
}