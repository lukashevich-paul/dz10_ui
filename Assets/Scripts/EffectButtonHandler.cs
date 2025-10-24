using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class EffectButtonHandler : MonoBehaviour
{
    private AudioSource _audioSource;
    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
    }
    protected void OnEnable()
    {
        _button.onClick.AddListener(Play);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        _audioSource.Play();
    }
}
