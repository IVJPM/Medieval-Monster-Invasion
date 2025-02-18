using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeAttributes : WeaponAttributes
{
    public static event EventHandler OnMeleeDisabled;
    public float activeWeaponTimer;

    [field: SerializeField] public AnimationClip meleeWeaponAnimation;
    [field: SerializeField] public AnimationClip meleeIdleClip;
    [field: SerializeField] public int meleeAnimationIndex;

    private Collider weaponCollider;

    private void Start()
    {
        weaponType = WeaponType.Melee;
        weaponCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            activeWeaponTimer += Time.deltaTime;
            if(activeWeaponTimer > 10)
            {
                gameObject.SetActive(false);
                activeWeaponTimer = 0;
                OnMeleeDisabled?.Invoke(this, EventArgs.Empty); // Try using the animations singleton to split different weapon animations up (refactor later with a better system)
            }
        }
    }
}
