using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public static AnimationsManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void PlayAnimation(Animator animator, AnimationClip clip, float animationsBlend)
    {
        animator.CrossFade(clip.name, animationsBlend);
    }
}
