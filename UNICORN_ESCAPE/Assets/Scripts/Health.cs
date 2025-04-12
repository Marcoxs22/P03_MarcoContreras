using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 3;
    [SerializeField]
    private UnityEvent<int> _onHealthChanged;
    [SerializeField]
    private UnityEvent _onDeath;
    [SerializeField]
    private UnityEvent _onRespawn;
    private int _currentHealth;

    public void SetHealth(int health)
    {
        _currentHealth = health;
        _onHealthChanged?.Invoke(_currentHealth);
    }

    public void OnReceiveDamage()
    {
        SetHealth(_currentHealth - 1);
        if(_currentHealth <= 0)
        {
            _onDeath.Invoke();
        }
        else
        {
            _onRespawn.Invoke();
        }
    }
}
