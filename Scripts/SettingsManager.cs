using UnityEngine;
using UnityEngine.UI; // for Slider and Toggle
using TMPro;

public class SettingsManager : MonoBehaviour
{
    // Declare variables for settings and input
    private int musicVolume;
    private bool soundEnabled;
    private string hostIP;

    // Reference to UI elements
    public Slider musicVolumeSlider;
    public Toggle soundToggle;
    public TMP_InputField hostIPInput;

    // PlayerPrefs keys
    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundEnabledKey = "SoundEnabled";
    private const string HostIPKey = "HostIP";

    void Awake()
    {
        // Load settings when the game starts
        LoadSettings();
    }

    void Start()
    {
    }

    // Function to save settings
    public void SaveSettings()
    {
        Debug.Log("Saving settings...");

        // Save music volume
        musicVolume = (int)musicVolumeSlider.value;
        PlayerPrefs.SetInt(MusicVolumeKey, musicVolume);
        Debug.Log("Music Volume saved: " + musicVolume);

        // Save sound enabled state
        soundEnabled = soundToggle.isOn;
        PlayerPrefs.SetInt(SoundEnabledKey, soundEnabled ? 1 : 0);
        Debug.Log("Sound Enabled saved: " + soundEnabled);

        // Save host IP
        hostIP = hostIPInput.text;
        PlayerPrefs.SetString(HostIPKey, hostIP);
        Debug.Log("Host IP saved: " + hostIP);

        // Save the PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs saved");
    }


    // Function to load settings
    public void LoadSettings()
    {
        Debug.Log("Loading settings...");

        // Load music volume
        if (PlayerPrefs.HasKey(MusicVolumeKey))
        {
            musicVolume = PlayerPrefs.GetInt(MusicVolumeKey);
            musicVolumeSlider.value = musicVolume;
            Debug.Log("Music Volume loaded: " + musicVolume);
        }
        else
        {
            Debug.Log("Music Volume key not found in PlayerPrefs.");
        }

        // Load sound enabled state
        if (PlayerPrefs.HasKey(SoundEnabledKey))
        {
            soundEnabled = PlayerPrefs.GetInt(SoundEnabledKey) == 1;
            soundToggle.isOn = soundEnabled;
            Debug.Log("Sound Enabled loaded: " + soundEnabled);
        }
        else
        {
            Debug.Log("Sound Enabled key not found in PlayerPrefs.");
        }

        // Load host IP
        if (PlayerPrefs.HasKey(HostIPKey))
        {
            hostIP = PlayerPrefs.GetString(HostIPKey);
            hostIPInput.text = hostIP;
            Debug.Log("Host IP loaded: " + hostIP);
        }
        else
        {
            Debug.Log("Host IP key not found in PlayerPrefs.");
        }

        Debug.Log("Save Settings Loaded");
    }

    // Function to get input
    public void GetInputServerSettings()
    {
        // Get the text from the TextMeshProUGUI component and store it in the variable
        hostIP = hostIPInput.text;

        // Now you can use 'hostIP' for further processing
        Debug.Log("Host IP: " + hostIP);
    }

    // Example: Call SaveSettings when a slider value changes
    public void OnMusicVolumeChanged(float value)
    {
        SaveSettings();
    }

    // Example: Call SaveSettings when a toggle value changes
    public void OnSoundToggleChanged(bool isOn)
    {
        SaveSettings();
    }

    // Example: Call SaveSettings when the "Save" button is clicked
    public void OnSaveButtonClicked()
    {
        SaveSettings();
    }

    // Public method to get the current hostIP
    public string GetHostIP()
    {
        hostIP = PlayerPrefs.GetString(HostIPKey);
        return hostIP;
    }
}
