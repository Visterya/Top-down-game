using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}
public enum PlayerFace
{
    Up,
    Down,
    Left,
    Right
}

public class Movement : MonoBehaviour
{
    [SerializeField][Range(0, 50)] private float moveSpeed;

    public PlayerState currentState;
    public PlayerFace currentFace;

    private Vector3 _change;
    private bool _timeToUpdateAnimationAndMove;

    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentState = PlayerState.walk;
        currentFace = PlayerFace.Down;
    }

    private void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

        if (currentState == PlayerState.walk)
        {
            _timeToUpdateAnimationAndMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (_timeToUpdateAnimationAndMove)
        {
            UpdateAnimationsAndMovement();
            _timeToUpdateAnimationAndMove = false;
        }
    }

    public void Move()
    {
        _rb.MovePosition(transform.position + _change.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void UpdateAnimationsAndMovement()
    {
        if (_change != Vector3.zero)
        {
            _animator.SetFloat("moveX", _change.x);
            _animator.SetFloat("moveY", _change.y);
            _animator.SetBool("running", true);
            UpdateFace();
            Move();
        }
        else
        {
            _animator.SetBool("running", false);
        }
    }

    private void UpdateFace()
    {
        if (_change.x > 0)
        {
            currentFace = PlayerFace.Right;
        }
        else if (_change.x < 0)
        {
            currentFace = PlayerFace.Left;
        }
        if (_change.y > 0)
        {
            currentFace = PlayerFace.Up;
        }
        else if (_change.y < 0)
        {
            currentFace = PlayerFace.Down;
        }
    }
}
