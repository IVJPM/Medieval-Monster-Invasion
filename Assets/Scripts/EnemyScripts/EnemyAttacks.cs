using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] AnimationClip attackAnimation;
    [SerializeField] SphereCollider enemyAttackCollider;
    [SerializeField] int enemyDamage;
    
    GameObject playerTarget;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindWithTag("Player");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnemyMovementAnimation()
    {
        AnimationsManager.instance.PlayAnimation(animator, attackAnimation, .25f);
    }

    public int EnemyAttackDamage()
    {
        return enemyDamage;
    }

    private void EnableEnemyAttackCollider()
    {
        enemyAttackCollider.enabled = true;
    }

    private void DisableEnemyAttackCollider()
    {
        enemyAttackCollider.enabled = false;
    }
}
