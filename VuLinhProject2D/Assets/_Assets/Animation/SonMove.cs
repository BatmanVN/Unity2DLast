using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D song2D;
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool faceLeft;
    void Start()
    {
        song2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if(Input.GetKeyDown(KeyCode.A) && !faceLeft) 
            {
                spriteRenderer.flipX = true;
                faceLeft = true;
            }
            song2D.velocity = Vector2.left * 2;
            animator.SetBool("Run",true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.D) && faceLeft) 
            {
                spriteRenderer.flipX = false;
                faceLeft = false;
            }
            song2D.velocity = Vector2.right * 2;
            animator.SetBool("Run",true);
        }
        else if(Input.GetKey(KeyCode.W)) 
        {
            song2D.velocity = Vector2.up * 2;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            song2D.velocity = Vector2.down * 2;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            song2D.velocity = Vector2.zero;
            animator.SetTrigger("KameAttack");
        }
        else if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D) ||
            !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.W))
        {
            song2D.velocity = Vector2.zero;
            animator.SetBool("Run", false);
        }
    }
    //private void FlipA()
    //{
    //    spriteRenderer.flipX = true;
    //}
    //private void FlipD()
    //{
    //    spriteRenderer.flipX = false;
    //}
}
