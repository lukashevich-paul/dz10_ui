using UnityEngine;
using UnityEngine.Audio;

public class SettingPanel : MonoBehaviour
{
    public const float PowerConversionFactor = 20f;
    public const float ZeroSliderValue = 0f;
    public const float MinimumVolume = -80f;

    public readonly string Master = nameof(Master);
    public readonly string Sound = nameof(Sound);
    public readonly string Effect = nameof(Effect);

    [SerializeField] private AudioMixer _mixer;

    private float _previousSliderValue = 0.7f;

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(Master, volume);
    }

    public void ChangeSoundVolume(float volume)
    {
        ChangeVolume(Sound, volume);
    }

    public void ChangeEffectVolume(float volume)
    {
        ChangeVolume(Effect, volume);
    }

    public void Mute()
    {
        ChangeMasterVolume(ZeroSliderValue);
    }

    public void Unmute()
    {
        ChangeMasterVolume(_previousSliderValue);
    }

    private void ChangeVolume(string mixerGroup, float volume)
    {
        float volumeValue = MinimumVolume;

        if (volume > 0)
        {
            _previousSliderValue = volume;
            volumeValue = Mathf.Log10(volume) * PowerConversionFactor;
        }

        _mixer.SetFloat(mixerGroup, volumeValue);
    }
}
