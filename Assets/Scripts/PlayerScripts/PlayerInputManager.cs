using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public float horizontalInput {  get; private set; }
    public float verticalInput { get; private set; }
    public Vector3 moveInput { get; private set; }

    public float upDownCameraMovement { get; private set; }
    public float leftRightCameraMovement { get; private set; }
    public Vector2 cameraInput { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInputs();
    }

    private void PlayerMovementInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveInput = new Vector3(horizontalInput, 0, verticalInput);
    }
}
