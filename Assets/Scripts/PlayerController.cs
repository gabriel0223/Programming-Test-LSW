using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform playerSprite;
    
    [SerializeField] private float speed;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<Animator>().transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;

        SpriteFlipping();
    }

    void SpriteFlipping()
    {
        if (moveInput.x == 0) return;

        playerSprite.localScale = new Vector2(rb.velocity.x > 0 ? 1 : -1, playerSprite.localScale.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput;
    }
}
