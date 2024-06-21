using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform cameraPositionOffset;
    [SerializeField] float leftRightRotation;
    [SerializeField] float upDownRotation;
    [SerializeField] Vector2 playerLookRotation;
    [SerializeField] Quaternion playerRotationAngles;
    [SerializeField] float maxLookAngle;
    [SerializeField] float minLookAngle;
    [SerializeField] float verticalLookAngle;


    [Header("Camera Inputs")]
    private float upDownLookAngle;
    private float leftRightLookAngle;
    Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*transform.position = cameraPositionOffset.position;
        leftRightRotation = Input.GetAxis("Mouse Y");
        upDownRotation = Input.GetAxis("Mouse X");
        playerLookRotation = new Vector2(upDownRotation, leftRightRotation);

        upDownLookAngle += playerLookRotation.x * 75f * Time.deltaTime;
        leftRightLookAngle -= playerLookRotation.y * 75f * Time.deltaTime;
        playerRotationAngles = Quaternion.Euler(0, upDownLookAngle, 0);
        Quaternion leftRight = Quaternion.Euler(leftRightLookAngle, 0, 0);
        transform.rotation = playerRotationAngles;
        Camera.main.transform.localRotation = leftRight;
        /*transform.position = cameraPositionOffset.position;

        leftRightRotation = Input.GetAxis("Mouse Y");
        upDownRotation = Input.GetAxis("Mouse X");
        playerLookRotation = new Vector2(upDownRotation, leftRightRotation);

        upDownLookAngle += playerLookRotation.x * 75f * Time.fixedDeltaTime;
        leftRightLookAngle -= playerLookRotation.y * 75f * Time.fixedDeltaTime;

        leftRightLookAngle = Mathf.Clamp(leftRightLookAngle, minLookAngle, maxLookAngle);

        playerRotationAngles = Quaternion.Euler(leftRightLookAngle, upDownLookAngle, 0);
        playerRotationAngles.Normalize();
        Quaternion rotatePlayer = Quaternion.Slerp(transform.rotation, playerRotationAngles, 900);

        transform.rotation = rotatePlayer;*/
        //transform.position = Vector3.SmoothDamp(transform.position, cameraPositionOffset.position, ref velocity, .1f);
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, cameraPositionOffset.position, 100), cameraPositionOffset.rotation);
    }
}
