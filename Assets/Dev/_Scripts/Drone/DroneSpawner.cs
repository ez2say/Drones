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
            CreateDroneAtBase(blueBase, true);
        }

        for (int i = 0; i < dronesPerFaction; i++)
        {
            CreateDroneAtBase(redBase, false);
        }
    }

    private void CreateDroneAtBase(IBase homeBase, bool isTeamA)
    {
        IDrone drone = _factory.Create(homeBase, isTeamA);

        if (drone is MonoBehaviour mono)
        {
            mono.transform.position = homeBase.Position + Random.insideUnitSphere * 2f;
        }
    }
}