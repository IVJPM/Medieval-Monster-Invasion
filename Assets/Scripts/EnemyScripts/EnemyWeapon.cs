using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int weaponDamage {  get; private set; }
    EnemyAttacks attacks;
    
    void Start()
    {
        attacks = GetComponentInParent<EnemyAttacks>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int WeaponDamage()
    {
        weaponDamage = attacks.EnemyAttackDamage();
        return weaponDamage;
    }
}
