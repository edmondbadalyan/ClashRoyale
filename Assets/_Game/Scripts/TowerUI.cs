using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Tower _tower;
    private float _maxHealth;

    private  void Start()
    {
        _healthBar.SetActive(false);
        _maxHealth = _tower.health.maxHealth;
        _tower.health.onHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth){
        _healthBar.SetActive(true);
        _healthBarFill.fillAmount = currentHealth / _maxHealth;
    }

    private void OnDestroy()
    {
        _tower.health.onHealthChanged -= UpdateHealthBar;
    }
}
