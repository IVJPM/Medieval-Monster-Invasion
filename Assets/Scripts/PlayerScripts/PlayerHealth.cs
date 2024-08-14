using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth, maxHealth;
    
    public bool isAlive {  get; private set; }

    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            isAlive = false;
            currentHealth = 0;
        }
    }

    public void RestoreHP(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetPlayerHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out EnemyWeapon enemy))
        {
            //Debug.Log(enemy.EnemyAttackDamage());
            TakeDamage(enemy.WeaponDamage());
        }
        else if(collider.gameObject.TryGetComponent(out HealHP healHp))
        {
            RestoreHP(healHp.RestoreHPAmount());
            Destroy(healHp.gameObject);
        }
    }
}
