using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private PlayerControl pControl;
    private Vector2 movement;
    private Rigidbody2D rb;

    private Animator playerAnim;
    private SpriteRenderer pSpriteRenderer;

    private void Awake()
    {
        //get all the required components at the start.
        pControl = new PlayerControl();
        playerAnim = GetComponent<Animator>();
        pSpriteRenderer = GetComponent<SpriteRenderer>();
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
        AdjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
    {
        //read movement input from the input system.
        movement = pControl.Movement.Move.ReadValue<Vector2>();
        //set the variable in the animator to trigger animation.
        if(movement.x !=0 || movement.y != 0)
        {
            playerAnim.SetBool("Moving", true);
        }
        else
        {
            playerAnim.SetBool("Moving", false);
        }

    }
    private void Move()
    {
        //move player.
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if(mousePos.x < playerScreenPoint.x)
        {
            pSpriteRenderer.flipX = true;
        }
        else
        {
            pSpriteRenderer.flipX=false;
        }
    }

}
