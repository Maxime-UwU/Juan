using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public Animator animator;
    public SpriteRenderer spriteRenderer; // Référence au SpriteRenderer

    public float horizontalMove = 0f;

    [SerializeField, Range(0f, 1f)]
    private float m_Deceleration;

    [Range(0, 1)]
    [SerializeField]
    private float m_CrouchSpeed = .36f;

    [SerializeField]
    public float m_MoveSpeed, m_JumpForce;

    [SerializeField]
    private Collider2D m_CrouchDisableCollider;

    private float _dir = 0;

    private bool _isGrounded = false;

    private bool _isJumping = false;

    private bool _isCrouching = false;

    [SerializeField]
    private LayerMask m_GroundMask;

    // Sprites pour l'état normal et l'état accroupi
    public Sprite standingSprite; // Sprite normal
    public Sprite crouchingSprite; // Sprite accroupi

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Récupère le SpriteRenderer
    }

    public void Move(float dir)
    {
        _dir = dir;
    }

    public void Jump()
    {
        if (_isGrounded)
            _isJumping = true;
        animator.SetBool("IsJumping", true);
    }

    public void Crouch()
    {
        if (_isGrounded)
        {
            _isCrouching = true;
            spriteRenderer.sprite = crouchingSprite; // Change le sprite quand on s'accroupit
        }
    }

    public void UnCrouch()
    {
        if (_isGrounded)
        {
            _isCrouching = false;
            spriteRenderer.sprite = standingSprite; // Restaure le sprite normal quand on se relève
        }
    }

    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * m_MoveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

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
            animator.SetBool("IsJumping", false);
            _rigidBody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }

        if (_isCrouching)
        {
            m_MoveSpeed = 4f;
            m_CrouchDisableCollider.enabled = false;
        }
        else
        {
            m_MoveSpeed = 8f;
            m_CrouchDisableCollider.enabled = true;
        }
    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, m_GroundMask);
    }
}
