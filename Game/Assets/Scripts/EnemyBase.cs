using UnityEngine;
using System;

public class EnemyBase : MonoBehaviour, IHaveHealth
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float sphereRadius = 1.0f;
    [SerializeField] private float castDistance = 5.0f;
    [SerializeField] private float maxHealth = 10f;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => maxHealth;
    public Action OnDamage { get; set;}
    public Action OnDeath { get; set;}

    private float _currentHealth;
    public void ChangeHealth(float damage)
    {
        _currentHealth += damage;
        if (damage < 0)
        {
            OnDamage?.Invoke();
        }
        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTrigger enter");
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Debug.Log($"Player detected");
        }
    }
}
