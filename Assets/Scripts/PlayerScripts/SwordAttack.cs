using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour, IWeapon
{
    private PlayerInputManager playerInputManager;
    private Animator playerAnimator;
    private GameObject currentMeleeWeapon;
    private EquipPlayerWeapon currentEquippedWeapon;
    private GameObject currentWeapon;

    [SerializeField] Transform weaponSlot;
    [SerializeField] float enableWeaponCollider;
    [SerializeField] float disableWeaponCollider;

    bool isAttacking;
    // Start is called before the first frame update
    void Awake()
    {
        playerInputManager = GetComponentInParent<PlayerInputManager>();
        playerAnimator = GetComponentInParent<Animator>();
        currentEquippedWeapon = GetComponentInParent<EquipPlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = currentEquippedWeapon.currentObject;
        if (currentWeapon == this.gameObject)
        {
            //print(currentWeapon);
            PlayerAttack();
        }
        else if(currentWeapon != this.gameObject)
        {

        }
    }

   

    private void OnDisable()
    {
        AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, 2, 0);
    }
    public void MeleeWeaponAttack()
    {
        AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeAnimationIndex, 1);
        if (playerInputManager.attack && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(ResetAttack());
        }
        else if (playerInputManager.attack && isAttacking)
        {
            return;
        }
    }

    IEnumerator ResetAttack()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeWeaponAnimation, .25f);
        yield return new WaitForSeconds(enableWeaponCollider);
        weaponSlot.GetComponentInChildren<Collider>().enabled = true;

        yield return new WaitForSeconds(disableWeaponCollider);

        weaponSlot.GetComponentInChildren<Collider>().enabled = false;
        AnimationsManager.instance.PlayAnimation(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeIdleClip, .25f);
        isAttacking = false;
    }

    public void PlayerAttack()
    {
        AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, currentWeapon.GetComponent<MeleeAttributes>().meleeAnimationIndex, 1);
        if (playerInputManager.attack && isAttacking == false)
        {
            isAttacking = true;
            StartCoroutine(ResetAttack());
        }
        else if (playerInputManager.attack && isAttacking)
        {
            return;
        }
    }
}
