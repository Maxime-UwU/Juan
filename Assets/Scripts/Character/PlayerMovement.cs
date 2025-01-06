using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField, Range(0f, 1f)]
    private float m_Deceleration;

    [SerializeField]
    public float m_MoveSpeed, m_JumpForce;


    private float _dir = 0;

    private bool _isGrounded = false;

    private bool _isJumping = false;

    [SerializeField]
    private LayerMask m_GroundMask;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Move(float dir)
    {
        _dir = dir;
    }

    public void Jump()
    {
        if (_isGrounded)
            _isJumping = true;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_dir) > 0.01f)
        {
            _rigidBody.velocity = new Vector2(_dir * m_MoveSpeed, _rigidBody.velocity.y);
        }
        else
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x * m_Deceleration, _rigidBody.velocity.y);
        }

        if (_isJumping)
        {
            _isJumping = false;

            _rigidBody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, m_GroundMask);
    }

    public void TakeDamage()
    {
        Debug.Log("dead !");
       
    }

    public void GetPowerUp()
    {
        Debug.Log("Boosted !");
        GameObject Player = GameObject.Find("Player");
        SpriteRenderer spriteRenderer = Player.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;

    }
  
}