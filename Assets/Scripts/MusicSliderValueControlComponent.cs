using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MusicSliderValueControlComponent : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] string _musicParameter = "MasterMusic";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] float _multiplyer = 30f;


    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener(HandleSliderValueChanger);
    }
    private void HandleSliderValueChanger(float value)
    {
        _mixer.SetFloat(_musicParameter, Mathf.Log10(value) * _multiplyer);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_musicParameter, _musicSlider.value);
    }
    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(_musicParameter, _musicSlider.value);
    }



}
