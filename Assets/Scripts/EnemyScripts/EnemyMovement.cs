using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    //GameObject playerTarget;
    Animator animator;
    AnimationClip currentAnimation;
    Rigidbody enemyRB;

    [SerializeField] AnimationClip chasingAnimation;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        //playerTarget = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //ChasePlayerTarget();
    }

    public void ChasePlayerTarget(GameObject playerTarget, float chaseSpeedValue)
    {
        Vector3 newPosition = playerTarget.transform.position;
        newPosition.y = transform.position.y;
        transform.LookAt(newPosition);

      //enemyRB.AddForce((enemyRB.transform.position + playerTarget.transform.position).normalized * speed * Time.deltaTime);
        transform.position -= (transform.position - playerTarget.transform.position).normalized * chaseSpeedValue * Time.deltaTime;
      //AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .1f);

        /*if (ScoreTracker.scoreCount > 20)
        {
            speed = 20;
        }
        animator.SetBool("Moving", true);*/
    }

    public void SetEnemyMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(animator, chasingAnimation, .25f);
    }
}
