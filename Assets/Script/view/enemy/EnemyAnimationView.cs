using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Stop()
    {
        animator.Play("idle_01");
    }

    public void Attack()
    {
        animator.Play("attack_01");
    }
}
