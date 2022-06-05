using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Eagle : Enemy, IEnemy
{
    [SerializeField] internal int m_Lifes = 1;
    [SerializeField] private int m_Damage = 1;
    [SerializeField] private float m_Speed = 45f;
    [SerializeField] private bool m_FacingRight = false;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.02f;
    [SerializeField] private LayerMask m_GroundMask;
    [SerializeField] internal Animator m_Animator;

    private Vector2 m_RayStart;
    private int xDir = -1;
    private int yDir = -1;
    private Transform player;
    private float ySpeed;
    private float minSpeed = 25;
    private float maxSpeed = 50;
    private float hitRange = 0.50f;
    [SerializeField] private bool canMove = true;

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
        ySpeed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.Find("Player").transform;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (!m_FacingRight)
        {
            xDir = 1;
            HFlip();
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
            m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Move();
    }

    public void Move()
    {
        m_RayStart = m_Rigidbody2D.position;

        var up = Physics2D.CircleCast(m_RayStart + new Vector2(0, 0.2f), 0.3f, Vector2.up, 0f, m_GroundMask);
        var down = Physics2D.CircleCast(m_RayStart - new Vector2(0, 0.2f), 0.3f, Vector2.down, 0f, m_GroundMask);
        var left = Physics2D.CircleCast(m_RayStart - new Vector2(0.2f, 0), 0.3f, Vector2.left, 0f, m_GroundMask);
        var right = Physics2D.CircleCast(m_RayStart + new Vector2(0.2f, 0), 0.3f, Vector2.right, 0f, m_GroundMask);
        if (left && left.collider.gameObject != gameObject && !m_FacingRight)
        {
            RightMovement();
            HFlip();
        }
        else if (right && right.collider.gameObject != gameObject && m_FacingRight)
        {
            LeftMovement();
            HFlip();
        }

        if (up && up.collider.gameObject != gameObject && m_Rigidbody2D.velocity.y > 0)
        {
            yDir = -1;
            ySpeed = Random.Range(minSpeed, maxSpeed);
        }
        else if (down && down.collider.gameObject != gameObject && m_Rigidbody2D.velocity.y < 0)
        {
            yDir = 1;
            ySpeed = Random.Range(minSpeed, maxSpeed);
        }
        var dist = Physics2D.Distance(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        var line = Physics2D.LinecastAll(m_RayStart, player.position, m_GroundMask);
        if (dist.distance < 7 && line.Length == 0)
        {
            m_Speed = 32.5f;
            FollowPlayer();
        }
        else
        {
            m_Speed = 25f;
            NeutralMovement();
        }
    }

    private void NeutralMovement()
    {
        Vector2 targetVelocity = new Vector2(m_Speed * 2f * Time.fixedDeltaTime * xDir, ySpeed * 2f * Time.fixedDeltaTime * yDir);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void FollowPlayer()
    {
        var displacement = player.position - new Vector3(0, 0.2f, 0) - transform.position;
        displacement = displacement.normalized;
        Vector2 target = displacement * m_Speed * Time.fixedDeltaTime * 2f;
        if (m_Rigidbody2D.velocity.y < 0)
            yDir = -1;
        else
            yDir = 1;

        if (m_Rigidbody2D.velocity.x < 0 && m_FacingRight)
        {
            LeftMovement();
            HFlip();
        }
        else if (m_Rigidbody2D.velocity.x > 0 && !m_FacingRight)
        {
            RightMovement();
            HFlip();
        }

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, target, ref m_Velocity, m_MovementSmoothing);

    }

    private void LeftMovement()
    {
        xDir = -1;
    }

    private void RightMovement()
    {
        xDir = 1;
    }

    private void HFlip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        base.CollisionOcurred(collision, m_Animator, m_Damage, hitRange);
    }
}
