using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField][Range(0,50)] private float moveSpeed;

    private float _inputX;
    private float _inputY;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputY = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        Vector2 move = new Vector2(_inputX, _inputY);
        move = move.normalized * moveSpeed;
        _rb.velocity = move;
    }
}
