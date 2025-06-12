using UnityEngine;

public interface IMove
{
    Vector3 position { get; }
    void MoveTowards(Vector3 target);
    bool HasReachedTarget(Vector3 target, float threshold = 0.5f);
    void SetSpeed(float speed);
}