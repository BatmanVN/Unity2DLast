using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float speedRun = 2f;
    [SerializeField] private Animator animator;
    private bool flippA = false;
    private bool flippD = false;
    private bool facingLeft;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(Input.GetKeyDown(KeyCode.A) && !facingLeft)
            {
                FlipA();
                facingLeft = true;
            }
                player.velocity = Vector2.left * 1;
                animator.SetTrigger("Move");

        }
        else if (Input.GetKey(KeyCode.D))
        {

            if (Input.GetKeyDown(KeyCode.D) && facingLeft)
            {
                FlipD();
                facingLeft = false;
            }
                player.velocity = Vector2.right * 1;
                animator.SetTrigger("Move");

            //Debug.Log(player.velocity);
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = Vector2.up*3;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            player.velocity = Vector2.right * speedRun;
            //Debug.Log(player.velocity);
        }
        if (!Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Stay");
        }
    }
    private void FlipA()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        flippA = !flippA;
    }
    private void FlipD()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        flippD = !flippD;
    }
}
