using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public const float PartOfMaxValue = 2f;

    [SerializeField, Min(0)] private float _maxValue = 100f;
    [SerializeField, Min(0)] private float _value = 100f;

    public event Action Changed;
    public event Action Died;

    public float MaxValue => _maxValue;
    public float Value => _value;

    public void TakeDamage(float damage)
    {
        _value -= damage;


        if (_value <= 0)
        {
            Died?.Invoke();
            _value = 0;
        }

        Changed?.Invoke();
    }

    public void TakeCure()
    {
        _value += MaxValue / PartOfMaxValue;

        if (_value > MaxValue)
            _value = MaxValue;

        Changed?.Invoke();
    }

    public void TakeCure(float value)
    {
        _value += value;

        if (_value > MaxValue)
            _value = MaxValue;

        Changed?.Invoke();
    }
}
