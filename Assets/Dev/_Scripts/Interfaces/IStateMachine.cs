public interface IStateMachine
{
    void ChangeState(IDroneState newState);
    void UpdateState();
}