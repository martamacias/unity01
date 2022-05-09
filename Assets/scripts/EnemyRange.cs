using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator animator;
    public EnemyAI enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            enemy.attack = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
