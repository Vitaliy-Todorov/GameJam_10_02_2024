using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int _maxValue;
    [SerializeField] 
    private int _value;
    [SerializeField] 
    private int _regeneration;
    [SerializeField] 
    private float _regenerationTime;

    public int MaxValue { get => _maxValue; }

    public event Action<Health> HealthAdd;

    public void TakeDamage(int damage)
    {
        AddHealth(-damage);
        HealthAdd?.Invoke(this);
        if(_value < _maxValue)
            StartCoroutine(Regeneration());

        if (_value <= 0)
            Destroy(gameObject);
    }

    private IEnumerator Regeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(_regenerationTime);
            AddHealth(-_regeneration);
        }
    }

    private void AddHealth(int value)
    {
        _value += value;
        HealthAdd?.Invoke(this);
    }
}
