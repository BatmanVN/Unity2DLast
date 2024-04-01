using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Collections.Unicode;

public class PlayerKnight : MonoBehaviour
{
    private const string isWalkingParaname = "isWalking";
    private const string isJumpParaname = "isJump";
    private const string isDizzyParaname = "isDizzy";
    private const string isHurtParaname = "isHurt";
    private const string isDashParaname = "isDash";
    private const string isCastParaname = "isCast";
    private const string isAttkParaname = "isAttk";
    private const string isWinParaname = "isWin";
    private const string isJumpAttkParaname = "isJumpAttk";
    private const string isDeathParaname = "isDeath";
    private const string isStrikeParaname = "isStrike";
    private const string isCrouchParaname = "isCrouch";
    private const string isRunParaname = "isRun";

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigid2D;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Vector2 jumpDirection;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float speed;
    bool isGrounded;
    bool isJumping = false;
    private UnityEvent inputs;

    private void PlayerHorizontalInput()
    {
        var isWalking = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
        var direction = moveDirection;
        if (isWalking && !Input.GetKey(KeyCode.LeftShift))
        {
            var isFlip = Input.GetKey(KeyCode.A);
            spriteRenderer.flipX = isFlip;
            if(isFlip)
                direction *= -1;
            if(isGrounded == false)
                rigid2D.velocity = direction;
        }
        animator.SetBool(isWalkingParaname, isWalking);
        //if (!isWalking && isJumping == false)
        //    rigid2D.velocity = Vector2.zero;
    }
    private void PlayerRun()
    {
        var isWalking = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
        var run = Input.GetKey(KeyCode.LeftShift) && isWalking;
        var direction = moveDirection;
        if (run && isGrounded == false)
        {
            var isFlip = Input.GetKey(KeyCode.A);
            spriteRenderer.flipX = isFlip;
            if (isFlip)
                direction *= -1;
            if(!Input.GetKey(KeyCode.C))
                rigid2D.velocity = direction * speed;
        }
        animator.SetBool(isRunParaname,run);
    }
    private void CheckUp()
    {
        //var isWalking = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A);
        //var jump = Input.GetKeyDown(KeyCode.Space);
        //var jumpMove = jump && isWalking;
        //var jumpdirection = jumpDirection;
        //var movedirection = moveDirection;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            //var isFlip = Input.GetKeyDown(KeyCode.A);
            //spriteRenderer.flipX = isFlip;
            //if(isFlip)
            //{
            //    jumpdirection  *= -1;
            //    animator.SetTrigger(isJumpParaname);
            //    rigid2D.velocity = jumpdirection;
            //}
            //else
                rigid2D.AddForce(jumpDirection);
                animator.SetTrigger(isJumpParaname);
             isJumping = true;
        }
        //if (jumpMove)
        //{
        //    var isFlip = Input.GetKeyDown(KeyCode.A);
        //    spriteRenderer.flipX = isFlip;
        //    if (isFlip)
        //        movedirection *= -1;
        //    animator.SetTrigger(isJumpParaname);
        //    rigid2D.AddForce(movedirection);
        //}
    }
    private void PlayerAttk()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger(isAttkParaname);
        }
    }
    private void PlayerJumpAttk()
    {
        CheckUp();
        if(Input.GetKeyDown(KeyCode.V))
        {
            if(isJumping)
                animator.SetTrigger(isJumpAttkParaname);
        }
    }
    private void CheckDown()
    {
        var crouch = Input.GetKey(KeyCode.C);
        animator.SetBool(isCrouchParaname, crouch);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void Start()
    {
        inputs = new UnityEvent();
        inputs.AddListener(PlayerHorizontalInput);
        inputs.AddListener(CheckUp);
        inputs.AddListener(CheckDown);
        inputs.AddListener(PlayerRun);
        inputs.AddListener(PlayerJumpAttk);
        inputs.AddListener(PlayerAttk);
    }
    void Update()
    {
        inputs?.Invoke();
    }
}
