using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Unit _unit;
    private float _maxHealth;

    private  void Start()
    {
        _healthBar.SetActive(false);
        _maxHealth = _unit.health.maxHealth;
        _unit.health.onHealthChanged += UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth){
        _healthBar.SetActive(true);
        _healthBarFill.fillAmount = currentHealth / _maxHealth;
    }

    private void OnDestroy()
    {
        _unit.health.onHealthChanged -= UpdateHealthBar;
    }

}
