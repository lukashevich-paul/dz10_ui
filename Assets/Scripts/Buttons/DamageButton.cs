using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField, Range(0,99)] private float _healthValue = 10f;
    [SerializeField] private Health _health;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Damage);
    }

    private void Damage()
    {
        _health.TakeDamage(_healthValue);
    }
}
