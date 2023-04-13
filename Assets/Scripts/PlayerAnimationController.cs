using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimationController : MonoBehaviour
{
    // Code like Me https://www.youtube.com/watch?v=p1_Om8viUJQ

    public Animator animator;
    private Player player;
    
    void Start()
    {
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No Animator Found");
            return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerKicking"))
        {
            player.kicking = false;
            animator.ResetTrigger("StartKick");
        }
        if (player.kicking) animator.SetFloat("Velocity", 0);
        animator.SetFloat("Velocity", player.getVelocity());
        //Debug.Log(player.getVelocity());
    }

    public void StartKick()
    {
        animator.SetTrigger("StartKick");
    }
}