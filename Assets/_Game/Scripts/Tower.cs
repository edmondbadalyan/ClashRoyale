using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour, IHealth, Idestroy
{
    [field: SerializeField] public Health health { get; private set; }
    [field: SerializeField] public float radius { get; private set; } = 2f;

    
    public event Action onDestroy;

    public float GetDistance(in Vector3 point) => Vector3.Distance(transform.position, point) - radius;


    private void Start()
    {
        health.onHealthChanged += CheckDestroy;
    }

    private void CheckDestroy(float currentHealth)
   {
    if (currentHealth > 0) return;
        Destroy(gameObject);
        health.onHealthChanged -= CheckDestroy;
        onDestroy?.Invoke();
   }

    
}
