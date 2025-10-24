using UnityEngine;
using UnityEngine.UI;

public class MuteUnmuteButtonHandler : MonoBehaviour
{
    public const float MinValue = 0f;
    public const float MaxValue = 1f;

    [SerializeField] private Button _muteButtom;
    [SerializeField] private Button _unmuteButtom;

    private bool _isMute = false;

    private void Awake()
    {
        Execute();
    }

    private void OnEnable()
    {
        _muteButtom.onClick.AddListener(Toggle);

        if (_muteButtom != _unmuteButtom)
            _unmuteButtom.onClick.AddListener(Toggle);
    }

    private void OnDisable()
    {
        _muteButtom.onClick.RemoveListener(Toggle);

        if (_muteButtom != _unmuteButtom)
            _unmuteButtom.onClick.RemoveListener(Toggle);
    }

    private void Toggle()
    {
        _isMute = !_isMute;

        Execute();
    }

    private void Execute()
    {
        AudioListener.volume = _isMute ? MinValue : MaxValue;

        if (_muteButtom != _unmuteButtom)
        {
            _muteButtom.gameObject.SetActive(!_isMute);
            _unmuteButtom.gameObject.SetActive(_isMute);
        }
        else if (_muteButtom.gameObject.activeSelf == false)
        {
            _muteButtom.gameObject.SetActive(true);
        }
    }
}
