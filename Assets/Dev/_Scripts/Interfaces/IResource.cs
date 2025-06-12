using UnityEngine;

public interface IResource
{
    Vector3 Position { get; }
    bool IsAvailable { get; }
    bool IsCollecting { get; }
    bool IsReserved { get; set; }
    void Collect();
    void ResetState();

}