using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePowerUp : MonoBehaviour
{
    public float destroyTimer;

    private int meleeWeaponIndex;
    [SerializeField] WeaponAttributes meleeWeapon;
    //public EquipMeleeWeapon equipMeleeWeapon;

    void Update()
    {
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out EquipPlayerWeapon playerWeapon))
        {
            playerWeapon.EquipWeapon(meleeWeapon.indexID);
            Destroy(gameObject);
        }
    }
}
