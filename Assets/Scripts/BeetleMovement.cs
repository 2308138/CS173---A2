using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    [SerializeField] public float speed = 0F;

    private Collider2D col;
    private Rigidbody2D rb;
    private Vector2 movement;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement != Vector2.zero)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);

        if (movement.x < 0)
            spriteRenderer.flipX = false;
        else if (movement.x > 0)
            spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 0.1F);
        if (hit.collider == null)
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        else
            Debug.Log("Collision Detected with: " + hit.collider.name);
    }
}