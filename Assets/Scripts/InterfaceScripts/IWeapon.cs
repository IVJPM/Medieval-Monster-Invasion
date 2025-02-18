using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    enum WeaponType
    {
        Sword,
        Axe
    }
    void PlayerAttack();
}
