using Unity.VisualScripting;
using UnityEngine;

public class ResourceSpawner
{
    private readonly IResourcePrototype _prototype;
    private readonly Vector2 _min;
    private readonly Vector2 _max;
    private readonly float _interval;

    private float _timer;

    private IResourceProvider _resourceProvider;

    public ResourceSpawner(
        IResourcePrototype prototype,
        IResourceProvider provider,
        Vector2 min, Vector2 max, float interval)
    {
        _prototype = prototype;
        _resourceProvider = provider;
        _min = min;
        _max = max;
        _interval = interval;
        _timer = 0f;
    }

    public void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _interval)
        {
            Spawn();
            _timer = 0f;
        }
    }

    private void Spawn()
    {
        IResource resource = _prototype.Clone();

        Vector3 position = new Vector3(
            Random.Range(_min.x, _max.x),
            0,
            Random.Range(_min.y, _max.y)
        );

        if (resource is MonoBehaviour mono)
        {
            mono.transform.position = position;
            mono.gameObject.SetActive(true);
        }

        _resourceProvider.Register(resource);
    }
}