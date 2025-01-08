using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField, Range(0f, 1f)]
    private float m_Deceleration;

    [Range(0, 1)][SerializeField]
    private float m_CrouchSpeed = .36f;

    [SerializeField]
    public float m_MoveSpeed, m_JumpForce;

    //[SerializeField]
    //private Collider2D m_CrouchDisableCollider;

    //[SerializeField]
    //private Collider2D m_CrouchDisableCollider2;

    private float _dir = 0;

    private bool _isGrounded = false;

    private bool _isJumping = false;

    //private bool _isCrouching = false;

    //[System.Serializable]
    //public class BoolEvent : UnityEvent<bool> { }

    //public BoolEvent OnCrouchEvent;
    //private bool m_wasCrouching = false;


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

    //public void Crouch()
    //{
    //    if (_isGrounded)
    //        _isCrouching = true;
    //}

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

        //if (_isCrouching)
        //{
        //    if (!m_wasCrouching)
        //    {
        //        m_wasCrouching = true;
        //        OnCrouchEvent.Invoke(true);
        //    }

        //    if (m_CrouchDisableCollider != null)
        //        m_CrouchDisableCollider.enabled = false;
        //        m_CrouchDisableCollider2.enabled = false;


        //    //_isCrouching = false;
        //    m_CrouchDisableCollider.enabled = false;
        //    //_rigidBody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        //}
        //else
        //{
        //    if (m_CrouchDisableCollider != null)
        //        m_CrouchDisableCollider.enabled = true;
        //        m_CrouchDisableCollider2.enabled = true;


        //    if (m_wasCrouching)
        //    {
        //        _isCrouching = false;
        //        m_wasCrouching = false;
        //        OnCrouchEvent.Invoke(false);
        //    }
        //}


    }

    private void Update()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, m_GroundMask);
    }
}