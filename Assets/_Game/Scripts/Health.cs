using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action<float> onHealthChanged;
    [field: SerializeField] public float maxHealth { get; private set; } = 10f;
    private float _currentHealth;

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
}

public interface IHealth
{
    Health health { get; }
}