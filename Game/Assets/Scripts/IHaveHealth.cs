using System;

public interface IHaveHealth
{
    public float CurrentHealth { get; }
    public float MaxHealth { get; }
    public Action OnDamage { get; set; }
    public Action OnDeath { get; set; }

    public void ChangeHealth(float damage);
}
