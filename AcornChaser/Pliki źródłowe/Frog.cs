using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy, IEnemy
{
    [SerializeField] internal int m_Lifes = 1;
    [SerializeField] private int m_Damage = 1;
    [SerializeField] private float m_Speed = 0f;
    [SerializeField] private bool m_FacingRight = false;
    [SerializeField] private LayerMask m_GroundMask;
    [SerializeField] internal Animator m_Animator;

    private float hitRange = 0.50f;

    internal Rigidbody2D m_Rigidbody2D;
    private float timer = 0;
    private float limit;
    private float minTime = 3;
    private float maxTime = 7;
    private Transform player;
    private int dir;

    [SerializeField] private bool canMove = true;
    private bool inAir = false;

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
        player = GameObject.Find("Player").transform;
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (!m_FacingRight)
            Flip();
    }

    private void Start()
    {
        limit = Random.Range(minTime, maxTime);
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Tock();
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
            m_Rigidbody2D.constraints |= RigidbodyConstraints2D.FreezeAll;
        if (inAir)
            CheckMovement();
        if (!m_Rigidbody2D.IsTouchingLayers(m_GroundMask))
            inAir = true;
    }

    private void CheckMovement()
    {
        if (m_Rigidbody2D.IsTouchingLayers(m_GroundMask))
        {
            m_Rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
            m_Animator.SetBool("isJumping", false);
            inAir = false;
        }
    }

    private void Tock()
    {
        timer++;
        if (timer >= limit)
        {
            if (!inAir && canMove)
            {
                Move();
            }
            timer = 0;
            limit = Random.Range(minTime, maxTime);
        }
    }

    public void Move()
    {
        m_Rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        var dist = Physics2D.Distance(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        if (dist.distance < 5)
            dir = player.position.x < m_Rigidbody2D.position.x ? -1 : 1;
        else
            dir = 0;
        if (dir == 1 && !m_FacingRight)
            Flip();
        else if (dir == -1 && m_FacingRight)
            Flip();
        m_Animator.SetBool("isJumping", true);
        if (dir != 0)
            m_Rigidbody2D.AddForce(new Vector2(250f * dir, 750f), ForceMode2D.Impulse);
        else
        {
            int rand = Random.Range(0, 2);
            if (rand == 0 && m_FacingRight)
                Flip();
            if (rand == 1 && !m_FacingRight)
                Flip();
            m_Rigidbody2D.AddForce(new Vector2(250f * (rand == 0 ? -1 : rand), 750f), ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        base.CollisionOcurred(collision, m_Animator, m_Damage, hitRange);
    }
}
