using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    private Animator playerAnimator;
    private GameObject currentMeleeWeapon;
    private EquipPlayerWeapon currentEquippedWeapon;
    private GameObject currentWeapon;

    [SerializeField] Transform weaponSlot;
    [SerializeField] AnimationClip meleeAttackClip;
    [SerializeField] AnimationClip meleeIdleClip;

    bool isAttacking;

    void Start()
    {
        playerInputManager = GetComponentInParent<PlayerInputManager>();
        playerAnimator = GetComponent<Animator>();
        currentEquippedWeapon = GetComponentInParent<EquipPlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = currentEquippedWeapon.currentObject;
        //Debug.Log(currentWeapon.GetComponent<MeleeAttributes>().meleeAnimationIndex);
        if(currentWeapon.GetComponent<MeleeAttributes>().isActiveAndEnabled)
        {
            print(currentWeapon.GetComponent<MeleeAttributes>().isActiveAndEnabled);
            MeleeWeaponAttack();
        }
        else
        {
            AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeAnimationIndex, 0);
            return;
        }
    }

    public void MeleeWeaponAttack()
    {
        AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeAnimationIndex, 1);
        if (playerInputManager.attack && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(ResetAttack());
        }
        else if(playerInputManager.attack && isAttacking)
        {
            return;
        }
    }

    IEnumerator ResetAttack()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeWeaponAnimation, .25f);
        yield return new WaitForSeconds(.5f);
        weaponSlot.GetComponentInChildren<Collider>().enabled = true;

        yield return new WaitForSeconds(1.25f);

        weaponSlot.GetComponentInChildren<Collider>().enabled = false;
        AnimationsManager.instance.PlayAnimation(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeIdleClip, .25f);
        isAttacking = false;
   }

    private void SwordAttack()
    {
        if(currentEquippedWeapon.GetComponent<MeleeAttributes>().indexID == 2)
        {
            //AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, 1, 1);
        }
    }

    private void AxeAttack()
    {

    }
}
