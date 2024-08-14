using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputManager playerInputManager;

    [Header("Player Movement Inputs")]
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    public Vector3 moveInput;
    [SerializeField] float leftRightRotation;
    [SerializeField] float upDownRotation;
    [SerializeField] Vector2 playerLookRotation;
    public Quaternion playerRotationAngles {  get; private set; }
    [SerializeField] float gravityModifier;


    [Header("Camera Inputs")]
    [SerializeField] float upDownLookAngle;
    [SerializeField] float leftRightLookAngle;
    [SerializeField] float maxLookAngle;
    [SerializeField] float minLookAngle;
    [SerializeField] float verticalLookAngle;

    private Rigidbody playerRB;
    private Animator playerAnimator;
    private bool speedIsBoosted;
    public float powerUpTimer;


    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        Physics.gravity *= gravityModifier;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RetrievePlayerMovementInputs();
    }

    void FixedUpdate()
    {
        //HandlePlayerMovement();
    }

    private void LateUpdate()
    {
       //HandlePlayerRotation();
    }

    private void RetrievePlayerMovementInputs()
    {
        horizontalInput = playerInputManager.horizontalInput;
        verticalInput = playerInputManager.verticalInput;
        moveInput = playerInputManager.moveInput;
    }

    public void HandlePlayerMovement(float movementSpeed)
    {        
        moveInput = new Vector3(horizontalInput, 0, verticalInput);
        moveInput.Normalize();
        moveInput.y = 0;
        
        playerRB.velocity = (playerRotationAngles * moveInput) * movementSpeed * Time.fixedDeltaTime;
    }

    public void HandlePlayerRotation()
    {
        leftRightRotation = Input.GetAxis("Mouse Y");
        upDownRotation = Input.GetAxis("Mouse X");
        playerLookRotation = new Vector2(upDownRotation, leftRightRotation);

        upDownLookAngle += playerLookRotation.x * 75f * Time.fixedDeltaTime;
        leftRightLookAngle -= playerLookRotation.y * 75f * Time.fixedDeltaTime;

        leftRightLookAngle = Mathf.Clamp(leftRightLookAngle, minLookAngle, maxLookAngle);

        playerRotationAngles = Quaternion.Euler(leftRightLookAngle, upDownLookAngle, 0);
        playerRotationAngles.Normalize();
        playerRB.MoveRotation(playerRotationAngles);
    }
}
