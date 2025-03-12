using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipPlayerWeapon : MonoBehaviour
{
    [field: SerializeField] public GameObject weaponSlot { get; private set; }
    public GameObject currentObject { get; private set; }
    //[field: SerializeField] public List <GameObject> weapons { get; private set; }

    Animator playerAnimator;
    ShootBow shootBow;
    MeleeAttack meleeAttack;
    public bool canMeleeAttack { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        meleeAttack = GetComponentInChildren<MeleeAttack>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weaponSlot.transform.childCount; i++)
        {
            if (weaponSlot.transform.GetChild(i).gameObject.activeSelf)
            {
                currentObject = weaponSlot.transform.GetChild(i).gameObject;
            }
        }
    }

    public void EquipWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponSlot.transform.childCount; i++)
        {
            weaponSlot.transform.GetChild(i).gameObject.SetActive(i == weaponIndex);
        }
    }

    private void OnEnable()
    {
        MeleeAttributes.OnMeleeDisabled += MeleeAttributes_OnMeleeDisabled;
    }

    private void OnDisable()
    {
        MeleeAttributes.OnMeleeDisabled -= MeleeAttributes_OnMeleeDisabled;
    }
    private void MeleeAttributes_OnMeleeDisabled(object sender, System.EventArgs e)
    {
        weaponSlot.transform.GetChild(0).gameObject.SetActive(true);
        currentObject = weaponSlot.transform.GetChild(0).gameObject;
    }
}
