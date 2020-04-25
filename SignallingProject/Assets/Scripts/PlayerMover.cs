using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _checkDistance = 0.15f;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _sprite;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnValidate()
    {
        if (_speed < 0f)
        {
            _speed = 0f;
        }

        if (_jumpForce < 0f)
        {
            _jumpForce = 0f;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Run(Vector3.right, false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Run(Vector3.left, true);     
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
        }
    }

    private void Run(Vector3 directionX, bool IsFlipSprite)
    {
        transform.Translate(directionX * _speed * Time.deltaTime);
        _sprite.flipX = IsFlipSprite;
        _animator.SetBool("isRunning", true);
    }

    private bool IsGrounded()
    {
        bool isGrounded;
        var collisionCount = _rigidbody2D.Cast(Vector2.down, _results, _checkDistance);

        if(collisionCount == 0)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;  
        }

        _animator.SetBool("isJumping", !isGrounded);

        return isGrounded;
    }
}
