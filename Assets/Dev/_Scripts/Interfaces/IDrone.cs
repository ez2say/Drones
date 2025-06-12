public interface IDrone
{
    IBase HomeBase { get; }
    IMove Mover { get; }
    IResourceCollector Collector { get; }
    IStateMachine StateMachine { get; }
    IResourceProvider ResourceProvider { get; } 

    void Initialize(IBase homeBase, IResourceProvider provider, float speed);
}