using UnityEngine;

public class SearchingState : IDroneState
{
    private readonly IResourceProvider _resourceProvider;
    private float _searchTimer = 0f;
    private const float _searchInterval = 1f;

    public SearchingState(IResourceProvider resourceProvider)
        => _resourceProvider = resourceProvider;

    public void Enter(IDrone drone) => TryFindAndMove(drone);

    public void Update(IDrone drone)
    {
        _searchTimer += Time.deltaTime;

        if (_searchTimer >= _searchInterval)
        {
            TryFindAndMove(drone);
            _searchTimer = 0f;
        }
    }

    private void TryFindAndMove(IDrone drone)
    {
        IResource closest = _resourceProvider.GetClosestResource(drone.Mover.position);

        if (closest != null)
        {
            drone.Collector.TargetResource = closest;
            drone.StateMachine.ChangeState(new MovingState(closest));
        }
        else
        {
            Debug.LogWarning("Ресурсы еще не найдены");
        }
    }

    public void Exit(IDrone drone) { }
}