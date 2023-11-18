using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PlayerJump playerJump;

    private void OnEnable()
    {
        playerJump.onPlayerJumpChange += HandlePlayerJumpChange;
        playerMove.onPlayerIdleChange += HandlePlayerIdleChange;
    }

    private void OnDisable()
    {
        playerJump.onPlayerJumpChange -= HandlePlayerJumpChange;
        playerMove.onPlayerIdleChange -= HandlePlayerIdleChange;
    }

    private void HandlePlayerIdleChange(bool isIdle) 
    {
        animator.SetBool("IsIdle", isIdle);
    }

    private void HandlePlayerJumpChange(bool isJumpinng)
    {
        animator.SetBool("IsJumping", isJumpinng);
    }
}
