using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] Transform playerTarget;
    GameObject playerTarget;
    Animator animator;
    [SerializeField] AnimationClip chasingAnimation;
    [SerializeField] AnimationClip attackAnimation;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayerTarget();
    }

    private void ChasePlayerTarget()
    {
        Vector3 newPosition = playerTarget.transform.position;
        newPosition.y = transform.position.y;
        transform.LookAt(newPosition);

        if(Vector3.Distance(transform.position, playerTarget.transform.position) > 2f)
        {
            transform.position -= (transform.position - playerTarget.transform.position).normalized * speed * Time.deltaTime;

            AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .1f);
        }
        if(Vector3.Distance(transform.position, playerTarget.transform.position) <= 2f)
        {
            //transform.position -= (transform.position - playerTarget.transform.position).normalized * 0 * Time.deltaTime;

            AnimationsManager.instance.PlayAnimation(animator, attackAnimation, .1f);
        }
        /*if (ScoreTracker.scoreCount > 20)
        {
            speed = 20;
        }
        animator.SetBool("Moving", true);*/
    }
}
