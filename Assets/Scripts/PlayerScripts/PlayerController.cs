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
    [SerializeField] float playerMoveSpeed;

    public bool speedIsBoosted;
    public float powerUpTimer;

    public enum PlayerState
    {
        Idle,
        Movement,
        Death
    };

    PlayerState playerState;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInputManager = GetComponent<PlayerInputManager>();
        playerAnimations = GetComponentInChildren<PlayerAnimations>();
        playerHealth = GetComponent<PlayerHealth>();

        shootBow = GetComponentInChildren<ShootBow>();
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
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
            playerMoveSpeed = 150;
        }
        if(playerHealth.isAlive == true)
        {
            shootBow.DrawBow();
            shootBow.BowShot();
        }
    }
    void FixedUpdate()
    {
        ChangePlayerState();
    }
    private void LateUpdate()
    {
        if(playerHealth.isAlive == true)
        playerMovement.HandlePlayerRotation();
    }

    private void ChangePlayerState()
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
    } //Player state change conditions 

    private void OnTriggerEnter(Collider other)
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
    } //Speed boost power up
}
