using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string settingName;
    private Text _volumeText;

    private void Awake()
    {
        _volumeText = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeName)*100f;
        _volumeText.text = settingName + volumeValue.ToString();
    }
}
