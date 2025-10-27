using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TreatButton : MonoBehaviour
{
    [SerializeField, Range(0, 99)] private float _healthValue = 10f;
    [SerializeField] private Health _health;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToTreat);
    }

    private void ToTreat()
    {
        _health.TakeCure(_healthValue);
    }
}
