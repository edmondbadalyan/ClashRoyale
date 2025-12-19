using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Health))]
public class Tower : MonoBehaviour, IHealth, Idestroy
{
    [field: SerializeField] public Health health { get; private set; }
    [field: SerializeField] public float radius { get; private set; } = 2f;

    
    public event Action onDestroy;

    public float GetDistance(in Vector3 point) => Vector3.Distance(transform.position, point) - radius;

    //private NavMeshObstacle _navMeshObstacle;

    private void Awake()
    {
       // _navMeshObstacle = GetComponent<NavMeshObstacle>();
    }
    private void Start()
    {
        health.onHealthChanged += CheckDestroy;
    }

    private void CheckDestroy(float currentHealth)
   {
    if (currentHealth > 0) return;
            //if (_navMeshObstacle != null)
            //     {
            //         _navMeshObstacle.enabled = false;
            //     }
        Destroy(gameObject);
        health.onHealthChanged -= CheckDestroy;
        onDestroy?.Invoke();
   }

    
}
