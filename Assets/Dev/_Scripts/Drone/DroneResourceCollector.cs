public class DroneResourceCollector : IResourceCollector
{
    private IBase _homeBase;
    private IResourceProvider _resourceProvider;
    public IResource TargetResource { get; set; }

    public void SetHomeBase(IBase homeBase) => _homeBase = homeBase;

    public void SetResourceProvider(IResourceProvider provider) => _resourceProvider = provider;

    public void PickUpResource()
    {
        if (TargetResource != null && TargetResource.IsAvailable)
            TargetResource.Collect();
    }

    public void DeliverResource()
    {
        if (TargetResource == null) return;
        _homeBase.AddResource();
        TargetResource = null;
    }
}