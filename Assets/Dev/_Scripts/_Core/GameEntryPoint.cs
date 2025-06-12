using TMPro;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject gameSetupUIPrefab;
    [SerializeField] private TMP_Text base1Text;
    [SerializeField] private TMP_Text base2Text;

    private IDroneFactory _droneFactory;
    private IDroneSpawner _droneSpawner;
    private ResourceSpawner _resourceSpawner;
    private IResourceProvider _resourceProvider;

    private void Awake()
    {
        gameSetupUIPrefab.SetActive(true);
        GameSetupUI.onStartGame += StartGame;
    }

    private void StartGame(DroneGameSettingsSO settings)
    {

        IBase blueBase = StartBlueBase(settings);
        IBase redBase = StartRedBase(settings);

        var droneProto = settings.dronePrefab.GetComponent<IDronePrototype>();
        var resourceProto = settings.resourcePrefab.GetComponent<IResourcePrototype>();

        CreateComponents(settings, droneProto, resourceProto);

        _droneSpawner.SpawnDrones(blueBase, redBase, settings.dronesPerFaction);

    }

    private void CreateComponents(DroneGameSettingsSO settings, IDronePrototype droneProto, IResourcePrototype resourceProto)
    {
        _resourceProvider = new SimpleResourceProvider();
        _droneFactory = new DroneFactory(droneProto, _resourceProvider, settings.droneSpeed,settings.teamAColor,settings.teamBColor);
        _droneSpawner = new DroneSpawner(_droneFactory, _resourceProvider);

        _resourceSpawner = new ResourceSpawner(
            resourceProto,
            _resourceProvider,
            settings.spawnAreaMin,
            settings.spawnAreaMax,
            settings.resourceSpawnInterval
        );
    }

    private IBase StartRedBase(DroneGameSettingsSO settings)
    {
        GameObject redBaseObj = Instantiate(settings.redBasePrefab,
                settings.redBaseSpawnPoint.transform.position,
                settings.redBaseSpawnPoint.transform.rotation);

        IBase redBase = redBaseObj.GetComponent<IBase>();
        if (redBase is Base baseImpl2)
        {
            baseImpl2.Initialize(base2Text,settings.teamBColor);
        }

        return redBase;
    }

    private IBase StartBlueBase(DroneGameSettingsSO settings)
    {
        GameObject blueBaseObj = Instantiate(settings.blueBasePrefab,
                settings.blueBaseSpawnPoint.transform.position,
                settings.blueBaseSpawnPoint.transform.rotation);

        IBase blueBase = blueBaseObj.GetComponent<IBase>();

        if (blueBase is Base baseImpl)
        {
            baseImpl.Initialize(base1Text,settings.teamAColor);
        }

        return blueBase;
    }

    private void Update()
    {
        _resourceSpawner?.Update();
    }
}