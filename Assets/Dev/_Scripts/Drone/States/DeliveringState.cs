using UnityEngine;

public class DeliveringState : IDroneState
{
    private float _deliverTimer;
    private const float _deliverDuration = 1f;

    public void Enter(IDrone drone) => _deliverTimer = 0f;

    public void Update(IDrone drone)
    {
        _deliverTimer += Time.deltaTime;

        if (_deliverTimer >= _deliverDuration)
        {
            drone.Collector.DeliverResource();
            drone.StateMachine.ChangeState(new SearchingState(drone.ResourceProvider));
        }
    }

    public void Exit(IDrone drone) { }
}