public class DroneFactory : IDroneFactory
{
    private readonly IDronePrototype _prototype;
    private readonly IResourceProvider _resourceProvider;
    private readonly float _speed;

    public DroneFactory(IDronePrototype prototype, IResourceProvider provider, float speed)
    {
        _prototype = prototype;
        _resourceProvider = provider;
        _speed = speed;
    }

    public IDrone Create(IBase homeBase)
    {
        IDrone drone = _prototype.Clone();
       
        drone.Initialize(homeBase, _resourceProvider,_speed);

        return drone;
    }
}