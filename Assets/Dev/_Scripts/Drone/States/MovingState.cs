using UnityEngine;

public class MovingState : IDroneState
{
    private readonly IResource _targetResource;

    public MovingState(IResource resource)
        => _targetResource = resource;

    public void Enter(IDrone drone)
    {
        if (_targetResource == null || !_targetResource.IsAvailable)
        {
            drone.StateMachine.ChangeState(new SearchingState(drone.ResourceProvider));
            return;
        }

        drone.Mover.MoveTowards(_targetResource.Position);
    }

    public void Update(IDrone drone)
    {
        if (_targetResource == null || !_targetResource.IsAvailable || _targetResource.IsCollecting)
        {
            drone.StateMachine.ChangeState(new SearchingState(drone.ResourceProvider));
            return;
        }

        drone.Mover.MoveTowards(_targetResource.Position);

        if (drone.Mover.HasReachedTarget(_targetResource.Position))
        {
            drone.StateMachine.ChangeState(new CollectingState());
        }
    }

    public void Exit(IDrone drone)
    {
        if (_targetResource != null && _targetResource.IsReserved)
        {
            _targetResource.IsReserved = false;
        }
    }
}