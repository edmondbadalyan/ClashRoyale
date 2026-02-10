using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    public event Action<float> onHealthChanged;
    [field: SerializeField] public float maxHealth { get; private set; } = 10f;
    private float _currentHealth;
    public float currentHealth => _currentHealth;

    private void Start(){
        _currentHealth = maxHealth;
    }
    public void ApplyDamage(float damage){
        _currentHealth -= damage;
        if (_currentHealth <= 0){
           _currentHealth = 0;
        }
        onHealthChanged?.Invoke(_currentHealth);
        Debug.Log($"Health: {_currentHealth} - {damage}" );
    }
    public void ApplyDelayDamage(float delay,float damage)
    {
        StartCoroutine(DelayDamage(delay,damage));
    }
    private IEnumerator DelayDamage(float delay, float damage)
    {
        yield return new WaitForSeconds(delay);
        ApplyDamage(damage);

    }
}

public interface IHealth
{
    Health health { get; }
}