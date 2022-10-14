using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplyer = 30f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanger);
    }

    private void HandleSliderValueChanger(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplyer);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }
    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

}
