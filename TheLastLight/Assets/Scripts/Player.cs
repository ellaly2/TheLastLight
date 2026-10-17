using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private InputActionReference attackAction;
    [SerializeField] private InputActionReference specialAction;
    [SerializeField] private InputActionReference magicAction;
    [SerializeField] private string attackStateTag = "Attack";
    [SerializeField] private Animator animator;

    private float _lastAttackTime;
    private float _attackIndex;
    private bool _isAttacking;

    private static readonly int QuickAttack1Hash = Animator.StringToHash("QuickAttack1");
    private static readonly int FollowUpAttackHash = Animator.StringToHash("FollowUpAttack");
    private static readonly int QuickAttack2Hash = Animator.StringToHash("QuickAttack2");
    private static readonly int HeavyAttack1Hash = Animator.StringToHash("HeavyAttack1");
    private static readonly int HeavyAttack2Hash = Animator.StringToHash("HeavyAttack2");

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        attackAction.action.performed += HandleAttack;
        specialAction.action.performed += HandleSpecial;
        magicAction.action.performed += HandleMagic;
    }

    private void OnDestroy()
    {
        attackAction.action.performed -= HandleAttack;
        specialAction.action.performed -= HandleSpecial;
        magicAction.action.performed -= HandleMagic;
    }

    private void Update()
    {
        if (_isAttacking && !animator.IsInTransition(0) && !animator.GetCurrentAnimatorStateInfo(0).IsTag(attackStateTag))
        {
            _isAttacking = false;
            _lastAttackTime = Time.time;
        }
    }



    private void HandleAttack(InputAction.CallbackContext ctx)
    {
        Debug.Log($"Attack");
        TryAttack(QuickAttack1Hash);
    }

    private void HandleSpecial(InputAction.CallbackContext ctx)
    {
        TryAttack(HeavyAttack1Hash);
    }

    private void HandleMagic(InputAction.CallbackContext ctx)
    {
        TryAttack(HeavyAttack2Hash);
    }

    private void TryAttack(int attackHash)
    {
        if (_isAttacking) { return; }
        _isAttacking = true;
        animator.SetTrigger(attackHash);
    }
}
