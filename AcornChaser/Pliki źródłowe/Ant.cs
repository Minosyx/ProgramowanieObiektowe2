using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : Enemy, IEnemy
{
    [SerializeField] internal int m_Lifes = 2;
    [SerializeField] private int m_Damage = 2;
    [SerializeField] private float m_Speed = 25f;
    [SerializeField] private bool m_FacingRight = true;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0f;
    [SerializeField] private LayerMask m_GroundMask;
    [SerializeField] internal Animator m_Animator;
    [SerializeField] private bool canMove = true;

    private Vector2 m_GroundRay = new Vector2(.65f, -1);
    private Vector2 m_FrontRay = new Vector2(1, 0);
    private Vector2 m_RayStart;

    private float hitRange = 0.5f;

    internal Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;

    public int Lifes { get => m_Lifes; set => m_Lifes = value; }
    public float Speed { get => m_Speed; set => m_Speed = value; }
    public Animator GetAnimator => m_Animator;
    public Rigidbody2D GetRigidbody2D => m_Rigidbody2D;
    public GameObject GetSelf => gameObject;
    public bool CanMove { get => canMove; set => canMove = value; }

    private void Awake()
    {
        base.IgnoreCollisions(GetSelf);
        GetComponent<Collider2D>().enabled = true;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (!m_FacingRight)
            Flip();
    }

    private void FixedUpdate()
    {
        if (!canMove)
            m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Move();
    }

    public void Move()
    {
        m_RayStart = new Vector2(m_Rigidbody2D.position.x, m_Rigidbody2D.position.y + 0.3f);

        RaycastHit2D gr_hit = Physics2D.Raycast(m_RayStart, m_GroundRay, 2f, m_GroundMask);
        RaycastHit2D fr_hit = Physics2D.Raycast(m_RayStart, m_FrontRay, 0.5f, m_GroundMask);

        if (!gr_hit || fr_hit)
        {
            Flip();
        }

        SlopeAdjustment();

        Vector2 targetVelocity = new Vector2(m_Speed * Time.fixedDeltaTime * 10f, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void SlopeAdjustment()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, m_GroundMask);
        if (hit && Mathf.Abs(hit.normal.x) > 0.1)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x - hit.normal.x * 0.6f, m_Rigidbody2D.velocity.y);
            transform.position = new Vector2(transform.position.x, transform.position.y + (-hit.normal.x * Mathf.Abs(m_Rigidbody2D.velocity.x) * Time.fixedDeltaTime * (m_Rigidbody2D.velocity.x - hit.normal.x > 0 ? 1 : -1)));
        }
    }
    private void Flip()
    {
        m_GroundRay = new Vector2(m_GroundRay.x * -1, m_GroundRay.y);
        m_FrontRay = new Vector2(m_FrontRay.x * -1, m_FrontRay.y);
        m_Speed *= -1; 
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        base.CollisionOcurred(collision, m_Animator, m_Damage, hitRange);
    }
}
