using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealth, maxHealth;

    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
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
    }
}
