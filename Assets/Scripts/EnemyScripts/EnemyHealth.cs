using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth;
    [SerializeField] int defenseAmount;
    public EnemyHealthUI healthUI;
    public bool isAlive { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = healthUI.healthSlider.maxValue;
        currentHealth = maxHealth;
        isAlive = true;
        if(ScoreTracker.scoreCount > 10)
        {
            defenseAmount += 20;
        }    
    }

    public void TakeDamage(int damageAmount)
    {
        damageAmount = damageAmount - defenseAmount;
        currentHealth -= damageAmount;

        Debug.Log(damageAmount);
        if (currentHealth <= 0)
        {
            isAlive = false;
            currentHealth = 0;

            Destroy(gameObject);

            ScoreTracker.scoreCount++;
            if (PowerUpsManager.instance.ChanceToSpawnPowerUp() == 4)
            {
                PowerUpsManager.instance.SpawnPowerUp(new Vector3(transform.position.x, transform.position.y + .75f, transform.position.z));
            }
        }
    }

    public float GetEnemyHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out WeaponAttributes playerWeapon))
        {
            TakeDamage(playerWeapon.weaponDamage);
        }
    }
}
