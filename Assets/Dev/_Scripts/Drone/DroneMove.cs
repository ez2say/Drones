using UnityEngine.AI;
using UnityEngine;

public class DroneMove : IMove
{
    private readonly NavMeshAgent _navMeshAgent;
    private readonly Transform _transform;

    public Vector3 position => _transform.position;

    public DroneMove(NavMeshAgent navMeshAgent, Transform transform)
    {
        _navMeshAgent = navMeshAgent;
        _transform = transform;
    }

    public void MoveTowards(Vector3 target) => _navMeshAgent.SetDestination(target);

    public bool HasReachedTarget(Vector3 target, float threshold = 0.5f)
    {
        return !_navMeshAgent.pathPending &&
               _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + threshold;
    }

    public void SetSpeed(float speed) => _navMeshAgent.speed = speed;
}