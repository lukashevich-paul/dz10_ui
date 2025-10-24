using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    public const float PowerConversionFactor = 20f;
    public const float MinimumVolume = -80f;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        float volumeValue = MinimumVolume;

        if (volume > 0)
        {
            volumeValue = Mathf.Log10(volume) * PowerConversionFactor;
        }

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, volumeValue);
    }
}
