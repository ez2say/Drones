using UnityEngine;

public class Resource : MonoBehaviour, IResource, IResourcePrototype
{
    public Vector3 Position => transform.position;
    public bool IsReserved { get; set; }
    public bool IsAvailable => _isAvailable;
    public bool IsCollecting => _isCollecting;

    [SerializeField] private ParticleSystem _resourceParticlePrefab;
    private bool _isAvailable = true;
    private bool _isCollecting;

    public void Collect()
    {
        _isAvailable = false;
        _isCollecting = true;
        IsReserved = false;
        Instantiate(_resourceParticlePrefab, Position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    public void ResetState()
    {
        _isAvailable = true;
        _isCollecting = false;
        IsReserved = false;
        gameObject.SetActive(true);
    }
    public IResource Clone()
    {
        return Object.Instantiate(this);
    }
}