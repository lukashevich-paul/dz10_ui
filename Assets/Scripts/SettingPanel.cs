using UnityEngine;
using UnityEngine.Audio;

public class SettingPanel : MonoBehaviour
{
    public const float MagicNumber = 20f;

    public readonly string MasterVolume = nameof(MasterVolume);
    public readonly string SoundVolume = nameof(SoundVolume);
    public readonly string EffectVolume = nameof(EffectVolume);

    [SerializeField] private AudioMixerGroup _masterMixer;
    [SerializeField] private AudioMixerGroup _soundMixer;
    [SerializeField] private AudioMixerGroup _effectMixer;

    public void ChangeMasterVolume(float volume)
    {
        _masterMixer.audioMixer.SetFloat(MasterVolume, Mathf.Log10(volume) * MagicNumber);
    }

    public void ChangeSoundVolume(float volume)
    {
        _soundMixer.audioMixer.SetFloat(SoundVolume, Mathf.Log10(volume) * MagicNumber);
    }

    public void ChangeEffectVolume(float volume)
    {
        _effectMixer.audioMixer.SetFloat(EffectVolume, Mathf.Log10(volume) * MagicNumber);
    }
}
