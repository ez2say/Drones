using UnityEngine;

public class DroneFactory : IDroneFactory
{
    private readonly IDronePrototype _prototype;
    private readonly IResourceProvider _resourceProvider;
    private readonly float _speed;
    private readonly Color _teamAColor;
    private readonly Color _teamBColor;

    public DroneFactory(IDronePrototype prototype, IResourceProvider provider, float speed, 
                       Color teamAColor, Color teamBColor)
    {
        _prototype = prototype;
        _resourceProvider = provider;
        _speed = speed;
        _teamAColor = teamAColor;
        _teamBColor = teamBColor;
    }

    public IDrone Create(IBase homeBase, bool isTeamA)
    {
        IDrone drone = _prototype.Clone();
        
        if (drone is MonoBehaviour mono && mono.TryGetComponent<Renderer>(out var renderer))
        {
            renderer.material.color = isTeamA ? _teamAColor : _teamBColor;
        }

        drone.Initialize(homeBase, _resourceProvider, _speed);
        return drone;
    }
}