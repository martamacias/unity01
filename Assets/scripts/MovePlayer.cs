using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float moveSpeed = 5f;
    float jumpSpeed = 15f;
    Rigidbody2D personaje;

    void Start()
    {
        personaje = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            personaje.velocity = new Vector2(moveSpeed, personaje.velocity.y);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            personaje.velocity = new Vector2(-moveSpeed, personaje.velocity.y);
        }
        else
        {
            personaje.velocity = new Vector2(0, personaje.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && CheckGround.isGrounded)
        {
            personaje.velocity = new Vector2(personaje.velocity.x, jumpSpeed);
        }
    }
}
