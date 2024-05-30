using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}
public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    public event Action OnTakeDamage;

    private void Update()
    {
       
        if (health.curValue == 0.0f)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }


    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        OnTakeDamage?.Invoke();
    }
}