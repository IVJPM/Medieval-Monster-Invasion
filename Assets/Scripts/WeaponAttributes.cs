using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAttributes : MonoBehaviour
{
    public enum WeaponType
    {
        Ranged,
        Melee,
        Magic
    }

    public WeaponType weaponType;

    [field: SerializeField] public int indexID { get; private set; }

    [field: SerializeField] public int weaponDamage { get; private set; }
    [field: SerializeField] public string weaponName { get; private set; }
    public MeshRenderer weaponRenderer { get; private set; }
}