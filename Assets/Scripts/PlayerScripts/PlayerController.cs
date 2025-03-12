using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;
using static WeaponAttributes;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerInputManager playerInputManager;
    PlayerAnimations playerAnimations;
    PlayerHealth playerHealth;

    Rigidbody playerRb;
    Animator playerAnimator;
    ShootBow shootBow;

    [SerializeField] AnimationClip idleClip;
    [SerializeField] AnimationClip deathClip;
    [SerializeField] PauseGame gameOverText;
    //[SerializeField] float playerMoveSpeed;

    [SerializeField] CharacterState currentCharacterState;
    [SerializeField] CharacterState attackState;
    [SerializeField] CharacterState idleState;
    [SerializeField] CharacterState locomotionState;
    [SerializeField] CharacterState deathState;

    // Move to different class once figured out how best to set up
    [SerializeField] Transform weaponSlot;

    WeaponType currentWeaponType;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInChildren<PlayerMovement>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerAnimations = GetComponentInChildren<PlayerAnimations>();
        playerHealth = GetComponent<PlayerHealth>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        shootBow = GetComponentInChildren<ShootBow>();

        currentCharacterState = idleState;
        currentCharacterState.RunState(gameObject);

    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
            SetPlayerState();
    }

    /*private void ChangePlayerState()
    {
        Debug.Log(currentWeaponType.ToString());
        switch (currentWeaponType)
        {
            case WeaponType.Ranged:
                {
                    shootBow.DrawBow();
                    shootBow.BowShot();
                    AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, 0, 1);

                    if (weaponSlot.GetComponentInChildren<WeaponAttributes>().weaponType != WeaponType.Ranged)
                    {
                        currentWeaponType = WeaponType.Melee;
                    }
                }
            break;
            case WeaponType.Melee:
                {
                    AnimationsManager.instance.AnimationLayerWeightIndex(playerAnimator, 1, 1);
                    if (weaponSlot.gameObject.GetComponentInChildren<WeaponAttributes>().weaponType != WeaponType.Melee)
                    {
                        currentWeaponType = WeaponType.Ranged;
                        for(int i = 0; i < weaponSlot.childCount; i++)
                        {
                            if(weaponSlot.GetChild(i).gameObject.GetComponent<WeaponType>() == WeaponType.Ranged)
                            {
                                weaponSlot.GetChild(i).gameObject.SetActive(true);
                            }
                        }
                    }
                }
            break;
        }
    }*/

    private void ChangeState(CharacterState desiredState)
    {
        //Being called in the 'SetPlayerState()' function
        if (currentCharacterState == desiredState)
        {
            return;
        }
        if (currentCharacterState != desiredState)
        {
            currentCharacterState.ExitState();
            currentCharacterState = desiredState;
            currentCharacterState?.EnterState();
        }
    }

    private void SetPlayerState()
    {
        bool isMoving;
        if (playerInputManager.moveInput != Vector3.zero && playerHealth.isAlive == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            ChangeState(locomotionState);
        }
        else if (!isMoving && !playerInputManager.attack && playerHealth.isAlive == true)
        {
            ChangeState(idleState);
        }
        else if (playerHealth.isAlive == false)
        {
            ChangeState(deathState);
            gameOverText.GameOver();
        }

        currentCharacterState.RunState(gameObject);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out SpeedBoostPowerUp boostPowerUp))
        {
            if (boostPowerUp.boosted == false && speedIsBoosted == false)
            {
                playerMoveSpeed = boostPowerUp.BoostPlayerSpeed(playerMoveSpeed + 150f);
            }
            speedIsBoosted = true;
            Destroy(other.gameObject);
        }
    } //Speed boost power up, will be moved to a different script dealing with power ups*/
}
