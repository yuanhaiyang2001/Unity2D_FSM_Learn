using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public PlayerInputHandler InputHandler;
    Rigidbody2D rb;

    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(InputHandler.MovementInput.x * 2.0f, rb.velocity.y);
    }

}
