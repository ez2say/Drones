public class DroneStateMachine : IStateMachine
{
    private IDroneState _currentState;
    private readonly IDrone _drone;

    public DroneStateMachine(IDrone drone)
    {
        _drone = drone;
    }

    public void ChangeState(IDroneState newState)
    {
        _currentState?.Exit(_drone);
        _currentState = newState;
        _currentState?.Enter(_drone);
    }

    public void UpdateState() => _currentState?.Update(_drone);
}