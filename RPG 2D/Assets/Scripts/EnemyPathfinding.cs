using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 moveDir;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * (Time.fixedDeltaTime * moveSpeed));
    }

    public void MoveTo(Vector2 toPosition)
    {
        moveDir = toPosition;
        Debug.Log(toPosition);
    }
}
