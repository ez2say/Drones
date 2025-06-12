using UnityEngine;

public class ReturnState : IDroneState
{
    public void Enter(IDrone drone)
    {
        Debug.Log($"Дрон возвращается на базу - {drone.HomeBase.Position}");
        drone.Mover.MoveTowards(drone.HomeBase.Position);
    }

    public void Update(IDrone drone)
    {
        if (drone.Mover.HasReachedTarget(drone.HomeBase.Position))
        {
            drone.StateMachine.ChangeState(new DeliveringState());
        }
    }

    public void Exit(IDrone drone) { }
}