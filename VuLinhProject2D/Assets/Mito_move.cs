using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mito_move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mito;
    [SerializeField] private Animator animator;
    private Transform currentPoint;
    [SerializeField] private GameObject pointa;
    [SerializeField] private GameObject pointb;
    private SpriteRenderer spriteRenderer;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        mito = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPoint = pointa.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mitoPoint = currentPoint.position - transform.position;
        speed = 0.5f;
        if(currentPoint == pointa.transform)
        {
            mito.velocity = new Vector2(-speed, 0);
        }
        else
        {
            mito.velocity = new Vector2(speed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointa.transform)
        {
            currentPoint = pointb.transform;
            spriteRenderer.flipX = false;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointb.transform)
        {
            currentPoint = pointa.transform;
            spriteRenderer.flipX = true;
        }
    }
}
