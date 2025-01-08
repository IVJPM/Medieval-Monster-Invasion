using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

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

    public bool speedIsBoosted;
    public float powerUpTimer;

    public enum PlayerArmedState
    {
        Idle,
        Movement,
        Death
    };

    PlayerArmedState armedState;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponentInChildren<PlayerMovement>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerAnimations = GetComponentInChildren<PlayerAnimations>();
        playerHealth = GetComponent<PlayerHealth>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();

        currentCharacterState = idleState;
        currentCharacterState.RunState(gameObject);

    }

    private void Update()
    {
        if (speedIsBoosted == true)
        {
            powerUpTimer += Time.deltaTime;
        }
        if (powerUpTimer > 10)
        {
            speedIsBoosted = false;
            powerUpTimer = 0;
        }
    }
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
            //ChangePlayerState();
            SetPlayerState();
    }
    /*private void LateUpdate()
    {
        if (Time.timeScale == 1)
        {
            if (playerHealth.isAlive == true)
            playerMovement.HandleRotation();
        }
    }*/

    /*private void ChangePlayerState()
    {
        switch(playerState)
        { 
            case PlayerState.Idle:
            {
                if(playerMovement.moveInput != Vector3.zero && playerHealth.isAlive == true)
                {
                     playerState = PlayerState.Movement;
                }
                else if(playerHealth.isAlive != true)
                {
                     playerState = PlayerState.Death;
                     AnimationsManager.instance.PlayAnimation(playerAnimator, deathClip, .25f);
                }
            }
            break;
            case PlayerState.Movement:
            {
                playerMovement.HandlePlayerMovement(playerMoveSpeed);

                if (playerMovement.moveInput == Vector3.zero && playerHealth.isAlive == true)
                {
                     playerState = PlayerState.Idle;
                }
                else if (playerHealth.isAlive != true)
                {
                     playerState = PlayerState.Death;
                     AnimationsManager.instance.PlayAnimation(playerAnimator, deathClip, .1f);
                }
            }
            break;
            case PlayerState.Death:
            {
                 gameOverText.GameOver(); //Create a main gameplay canvas to hold pausing, score tracking, and game over
            }
            break;
        }
    } //Player state change conditions */

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
        else if (!isMoving && playerHealth.isAlive == true)
        {
            ChangeState(idleState);
        }
        else
        {
            ChangeState(deathState);
            gameOverText.GameOver();
        }

        currentCharacterState.RunState(gameObject);
    }

    private void OnEnable()
    {
        MeleePowerUp.OnMeleePowerUp += MeleePowerUp_OnMeleePowerUp;
    }

    private void OnDisable()
    {
        MeleePowerUp.OnMeleePowerUp -= MeleePowerUp_OnMeleePowerUp;
    }

    private void MeleePowerUp_OnMeleePowerUp(object sender, System.EventArgs e)
    {
        if(weaponSlot.GetComponentInChildren<WeaponAttributes>().weaponType != WeaponAttributes.WeaponType.Melee)
        {
            print("New weapon");
        }
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
