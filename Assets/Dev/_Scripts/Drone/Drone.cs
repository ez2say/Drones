using UnityEngine.AI;
using UnityEngine;

public class Drone : MonoBehaviour, IDrone, IDronePrototype
{
    public IBase HomeBase { get; private set; }
    public IMove Mover { get; private set; }
    public IResourceCollector Collector { get; private set; }
    public IStateMachine StateMachine { get; private set; }
    public IResourceProvider ResourceProvider { get; private set; }

    private NavMeshAgent _navMeshAgent;

    public void Initialize(IBase homeBase, IResourceProvider provider, float speed)
    {
        HomeBase = homeBase;
        ResourceProvider = provider;
        _navMeshAgent = GetComponent<NavMeshAgent>();

        Mover = new DroneMove(_navMeshAgent, transform);
        Collector = new DroneResourceCollector();
        StateMachine = new DroneStateMachine(this);

        Mover.SetSpeed(speed);
        Collector.SetHomeBase(homeBase);
        Collector.SetResourceProvider(provider);
        StateMachine.ChangeState(new SearchingState(provider));
    }

    public IDrone Clone() => Instantiate(this);

    private void Update() => StateMachine?.UpdateState();
}