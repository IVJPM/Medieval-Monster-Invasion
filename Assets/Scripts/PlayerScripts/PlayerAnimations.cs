using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //May not actually need this script for this game, but I'm keeping it as a reference for future games that it may be beneficial for
    private Animator playerAnimator;

    [SerializeField] AnimationClip runAnimation;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(playerAnimator, runAnimation, .1f);
    }
}
