public interface IDroneState
{
    void Enter(IDrone drone);
    void Update(IDrone drone);
    void Exit(IDrone drone);
}