using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerControl pControl;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        //get all the required components at the start.
        pControl = new PlayerControl();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        pControl.Enable();
    }
    
    private void Update()
    {
        //handle input.
        PlayerInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void PlayerInput()
    {
        //read movement input from the input system.
        movement = pControl.Movement.Move.ReadValue<Vector2>();
    }
    private void Move()
    {
        //move player.
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

}
