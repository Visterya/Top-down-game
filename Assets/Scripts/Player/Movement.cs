using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField][Range(0,50)] private float moveSpeed;

    private float _inputX;
    private float _inputY;
    private Vector3 _change;

    [Header("Components")]
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        if (_change != Vector3.zero)
        {
            Move();
            UpdateAnimations();
        }
        else
        {
            _animator.SetBool("running", false);
        }
    }
    public void Move()
    {
        _rb.MovePosition(transform.position + _change.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    public void UpdateAnimations()
    {
        _animator.SetFloat("moveX", _change.x);
        _animator.SetFloat("moveY", _change.y);
        _animator.SetBool("running", true);
    }
}
