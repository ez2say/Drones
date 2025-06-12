using UnityEngine;
using TMPro;

public class Base : MonoBehaviour, IBase
{
    public Vector3 Position => transform.position;
    public int ResourceCount => _resourceCount;

    private TMP_Text _resourcesText;

    private int _resourceCount;

    public void Initialize(TMP_Text resourcesText)
    {
        _resourcesText = resourcesText;
        UpdateResourcesUI();
    }

    public void AddResource()
    {
        _resourceCount++;
        UpdateResourcesUI();
    }

    private void UpdateResourcesUI()
    {
        if (_resourcesText != null)
        {
            _resourcesText.text = $"Ресурсы: {_resourceCount}";
        }
    }
}