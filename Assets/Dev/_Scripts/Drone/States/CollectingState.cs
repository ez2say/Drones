using UnityEngine;

public class CollectingState : IDroneState
{
    private float _collectTimer;
    private const float _collectDuration = 2f;

    public void Enter(IDrone drone)
        => _collectTimer = 0f;

    public void Update(IDrone drone)
    {
        _collectTimer += Time.deltaTime;

        if (_collectTimer >= _collectDuration)
        {
            drone.Collector.PickUpResource();
            drone.StateMachine.ChangeState(new ReturnState());
        }
    }

    public void Exit(IDrone drone) { }
}