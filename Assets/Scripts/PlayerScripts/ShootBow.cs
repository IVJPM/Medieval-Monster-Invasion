using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootBow : MonoBehaviour
{
    public static event EventHandler OnBowShot;

    [Header("Animation Clips")]
    [SerializeField] AnimationClip drawArrowClip;
    [SerializeField] AnimationClip fireArrowClip;
    [SerializeField] AnimationClip returnToIdleClip;

    [Header("Audio Clips")]
    [SerializeField] AudioClip drawBowStringSFX;
    [SerializeField] AudioClip shootArrowSFX;

    [Header("Misc(Organize Later)")]
    [SerializeField] GameObject bowString;
    [SerializeField] Transform rightHandPos;
    [SerializeField] Transform arrowSpawnPoint;
    [SerializeField] float drawBowStringSmoothing;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] List<GameObject> arrowPrefabArray = new List<GameObject>();

    private float drawBowStringTimer;
    GameObject arrow;


    Vector3 bowStringPos;
    Vector3 fireArrowStringPos;
    Vector3 arrowPosition;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;

    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        bowStringPos = bowString.transform.localPosition;
        fireArrowStringPos = rightHandPos.localPosition;
        fireArrowStringPos.x -= .025f;
        fireArrowStringPos.z += .025f;
        fireArrowStringPos.y -= .0575f;

        drawBowStringTimer = .1f;

        arrow = arrowPrefab;
    }

    void Update()
    {

    }

    public void DrawBow()
    {
        if(Input.GetMouseButtonDown(0))
        {
            drawBowStringSmoothing += Time.deltaTime;
            if (drawBowStringSmoothing <= 1.5f)
            {
                AnimationsManager.instance.PlayAnimation(playerAnimator, drawArrowClip, .1f * Time.deltaTime);

                if (arrowPrefabArray.Count < 1)
                {
                    arrowPrefabArray.Add(arrow);

                    Instantiate(arrow, arrowSpawnPoint.transform.position, arrowSpawnPoint.transform.rotation * Quaternion.Euler(16, 0, 0),
                    arrowSpawnPoint.transform.parent);
                }

                if (drawBowStringSmoothing >= .7f)
                {
                    drawBowStringTimer += Time.deltaTime;

                    bowString.transform.localPosition = Vector3.Lerp(bowStringPos, -fireArrowStringPos / 2.5f, drawBowStringTimer * 3.5f);
                }
            }
            if (drawBowStringSmoothing < .01f)
            {
                SoundFXManager.Instance.DrawBowSound(playerAudioSource, drawBowStringSFX, 1f);
            }

            else if (drawBowStringSmoothing >= 1.5f)
            {
                drawBowStringSmoothing = 1.5f;
            }
        }
    }

    public void BowShot()
    {
        //Break up into smaller methods to use with player state machine
                
        if(Input.GetMouseButtonUp(0))
        {
            OnBowShot?.Invoke(this, EventArgs.Empty);

            SoundFXManager.Instance.ShootBowSound(playerAudioSource, shootArrowSFX, 1f);
            AnimationsManager.instance.PlayAnimation(playerAnimator, fireArrowClip, .1f);

            arrowPrefabArray.Remove(arrow);

            bowString.transform.localPosition = Vector3.Lerp(bowString.transform.localPosition, bowStringPos, 1f);
            drawBowStringSmoothing = 0;
            drawBowStringTimer = 0;
        }
        //Set Idle animation with specified time after firing
    }
}
