using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneGameSettings", menuName = "Drone/Settings")]
public class DroneGameSettingsSO : ScriptableObject
{
    [Header("��������� �����������")]
    public bool showPaths = true;
    [Header("�����")]
    public GameObject dronePrefab;
    [Range(1, 20)] public int dronesPerFaction = 4;
    [Min(0.1f)] public float droneSpeed = 1f;

    [Header("����")]
    public GameObject blueBasePrefab;
    public GameObject redBasePrefab;
    public TMP_Text base1Text;
    public TMP_Text base2Text;

    [Header("�������")]
    public GameObject blueBaseSpawnPoint;
    public GameObject redBaseSpawnPoint;

    [Header("�������")]
    public GameObject resourcePrefab;
    public Vector2 spawnAreaMin = new Vector2(-10, -10);
    public Vector2 spawnAreaMax = new Vector2(10, 10);
    [Min(0.1f)] public float resourceSpawnInterval = 5f;
}