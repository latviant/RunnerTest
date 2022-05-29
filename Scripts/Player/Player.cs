using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private UnityEvent _damageTaken;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction<int> SpeedChanged;
   
    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }


    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
        DecreaseSpeed(damage);

        _damageTaken?.Invoke();
    }

    public void Die()
    {
        Died?.Invoke();
        Time.timeScale = 0;
    }

    private void DecreaseSpeed(int damage)
    {
        if (damage > 0)
            SpeedChanged?.Invoke(damage);
    }

}
