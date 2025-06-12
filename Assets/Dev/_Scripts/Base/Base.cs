using UnityEngine;
using TMPro;

public class Base : MonoBehaviour, IBase
{
    public Vector3 Position => transform.position;
    public int ResourceCount => _resourceCount;

    [SerializeField] private ParticleSystem _deliveryParticlePrefab;

    private Renderer _baseRenderer;
    private TMP_Text _resourcesText;
    private int _resourceCount;
    private Color _teamColor;

    public void Initialize(TMP_Text resourcesText, Color teamColor)
    {
        _resourcesText = resourcesText;
        _teamColor = teamColor;
        _baseRenderer = GetComponent<Renderer>();


        _baseRenderer.material.color = teamColor;

        UpdateResourcesUI();
    }

    public void AddResource()
    {
        _resourceCount++;
        Instantiate(_deliveryParticlePrefab, Position, Quaternion.identity);
        UpdateResourcesUI();
    }

    private void UpdateResourcesUI()
    {
        if (_resourcesText != null)
        {
            string colorName = _teamColor == Color.blue ? "Синие" : "Красные";
            _resourcesText.text = $"{colorName}собрали ресурсов: {_resourceCount}";
        }
    }
}