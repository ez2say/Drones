public interface IResourceCollector
{
    IResource TargetResource { get; set; }
    void SetHomeBase(IBase homeBase);
    void SetResourceProvider(IResourceProvider provider);
    void PickUpResource();
    void DeliverResource();
}