using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSetupUI : MonoBehaviour
{
    public delegate void OnStartGame(DroneGameSettingsSO settings);
    public static event OnStartGame onStartGame;

    [SerializeField] private Slider dronesSlider;
    [SerializeField] private TMP_Text dronesValueText;

    [SerializeField] private TMP_InputField intervalInput;
    [SerializeField] private TMP_Text intervalValueText;

    [SerializeField] private Slider speedSlider;
    [SerializeField] private TMP_Text speedValueText;

    [SerializeField] private Button startButton;

    [SerializeField]private DroneGameSettingsSO _settings;



    private void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        CountDroneSliderSetting();
        DroneSpeedSliderSetting();

        dronesSlider.value = _settings.dronesPerFaction;
        intervalInput.text = _settings.resourceSpawnInterval.ToString();
        speedSlider.value = _settings.droneSpeed;

        UpdateTexts();

        dronesSlider.onValueChanged.AddListener(OnDronesChanged);
        intervalInput.onEndEdit.AddListener(OnIntervalChanged);
        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        startButton.onClick.AddListener(OnStartClicked);
    }

    private void DroneSpeedSliderSetting()
    {
        speedSlider.minValue = 1;
        speedSlider.maxValue = 10;
        speedSlider.wholeNumbers = true;
    }

    private void CountDroneSliderSetting()
    {
        dronesSlider.minValue = 1;
        dronesSlider.maxValue = 5;
        dronesSlider.wholeNumbers = true;
    }

    private void OnDronesChanged(float value)
    {
        _settings.dronesPerFaction = Mathf.RoundToInt(value);
        UpdateTexts();
    }


    private void OnIntervalChanged(string input)
    {
        if (float.TryParse(input, out float interval))
            _settings.resourceSpawnInterval = interval;
        else
            intervalInput.text = _settings.resourceSpawnInterval.ToString();

        UpdateTexts();
    }

    private void OnSpeedChanged(float value)
    {
        _settings.droneSpeed = value;
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        dronesValueText.text = _settings.dronesPerFaction.ToString();
        intervalValueText.text = _settings.resourceSpawnInterval.ToString("F1");
        speedValueText.text = _settings.droneSpeed.ToString("F1");
    }

    private void OnStartClicked()
    {
        onStartGame?.Invoke(_settings);
        gameObject.SetActive(false);
    }
}