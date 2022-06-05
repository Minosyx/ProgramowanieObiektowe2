using UnityEngine;
using UnityEngine.Events;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
    [SerializeField] private bool m_AirControl = false;                         
    [SerializeField] private LayerMask m_WhatIsGround;                          
    [SerializeField] private Transform m_GroundCheck;                          
    [SerializeField] private Transform m_CeilingCheck;                         
    [SerializeField] private Collider2D m_CrouchDisableCollider;               


    private Animator anim;
    private const float k_GroundedRadius = .2f; 
    private bool m_Grounded;            
    private const float k_CeilingRadius = .2f; 
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    public UnityEvent JumpEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

        if (JumpEvent == null)
            JumpEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        if (colliders.Length == 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Hurt"))
        {
            JumpEvent.Invoke();
            m_AirControl = true;
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player_Hurt"))
            m_AirControl = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        if (m_Grounded || m_AirControl)
        {
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                move *= m_CrouchSpeed;

                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            SlopeAdjustment();

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        if (m_Grounded && jump)
        {
            m_Grounded = false;
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce) * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void SlopeAdjustment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, m_WhatIsGround);
        if (hit && Mathf.Abs(hit.normal.x) > 0.1)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x - hit.normal.x * 1f, m_Rigidbody2D.velocity.y);
            transform.position = new Vector2(transform.position.x, transform.position.y + (-hit.normal.x * Mathf.Abs(m_Rigidbody2D.velocity.x) * Time.fixedDeltaTime * (m_Rigidbody2D.velocity.x - hit.normal.x > 0 ? 1 : -1)));
        }
    }

    public void Launch()
    {
        m_Rigidbody2D.AddForce(new Vector2(0f, (m_Rigidbody2D.velocity.y == 0 ? 0.2f : 0.8f) * m_JumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}