using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ILocomotion
{
    PlayerInputManager playerInputManager;

    [Header("Player Movement Inputs")]
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    public Vector3 moveInput;
    [SerializeField] float leftRightRotation;
    [SerializeField] float upDownRotation;
    [SerializeField] Vector2 playerLookRotation;

    [SerializeField] Transform shin;
    [SerializeField] Transform feet;
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
    [SerializeField] LayerMask groundedMask;

    RaycastHit groundedCastHit;
    RaycastHit feetCastHit;

    private bool speedIsBoosted;
    private bool isGrounded;
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
        //CheckIfGrounded();
    }

    void FixedUpdate()
    {
        CheckIfGrounded();
        if (!CheckIfGrounded())
        {
            playerRB.AddForce(Vector3.down * 3f, ForceMode.Impulse);
        }
        //HandlePlayerMovement(400);
    }

    private void LateUpdate()
    {
        if (Time.timeScale == 1)

            HandleRotation();
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

        if (CheckIfGrounded())
        {
            playerRB.linearVelocity = (playerRotationAngles * moveInput) * movementSpeed * Time.fixedDeltaTime;
        }

        if(OnSlope())
        {
            playerRB.useGravity = false;
            playerRB.linearVelocity = GetClimbingDirection() * movementSpeed * Time.fixedDeltaTime;

            if (playerRB.linearVelocity.y > 0f)
            {
                playerRB.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        else if(!OnSlope() && CheckIfGrounded())
        {
            playerRB.useGravity = true;
            playerRB.linearVelocity = (playerRotationAngles * moveInput) * movementSpeed * Time.fixedDeltaTime;
        }
    }

    public void HandleRotation()
    {
        leftRightRotation = Input.GetAxis("Mouse Y");
        upDownRotation = Input.GetAxis("Mouse X");
        playerLookRotation = new Vector2(leftRightRotation, upDownRotation);

        upDownLookAngle -= playerLookRotation.x * 75f * Time.fixedDeltaTime;
        leftRightLookAngle += playerLookRotation.y * 75f * Time.fixedDeltaTime;

        upDownLookAngle = Mathf.Clamp(upDownLookAngle, minLookAngle, maxLookAngle);

        playerRotationAngles = Quaternion.Euler(upDownLookAngle, leftRightLookAngle, 0);
        playerRotationAngles.Normalize();
        playerRB.MoveRotation(playerRotationAngles);
    }

    private bool CheckIfGrounded()
    {
        if(Physics.SphereCast(shin.position, .225f, transform.TransformDirection(Vector3.down), out groundedCastHit, .15f, groundedMask))
        {
            return true;
        }
        return false;
    }

    private bool OnSlope()
    {
        if (Physics.SphereCast(shin.position, .225f, transform.TransformDirection(Vector3.down), out groundedCastHit, .15f, groundedMask))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, groundedCastHit.normal);
            return slopeAngle < 55 ;
        }
        return false;
    }

    private Vector3 GetClimbingDirection()
    {
        return Vector3.ProjectOnPlane(playerRB.linearVelocity, groundedCastHit.normal).normalized;
    }
}
