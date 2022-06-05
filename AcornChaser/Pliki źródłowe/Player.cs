using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerController2D m_PlayerControllerScript;

    [SerializeField] internal Animator m_Animator;

    private Vector2 movement = Vector2.zero;

    public float speed = 40f;

    public bool jump = false;

    public bool crouch = false;

    private bool allowDamage = true;

    [Header("Events")]

    public UnityEvent<int> m_DamageReceived;

    private void Awake()
    {
        if (m_DamageReceived == null)
            m_DamageReceived = new UnityEvent<int>();
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }

    private void FixedUpdate()
    {
        m_PlayerControllerScript.Move(movement.x * speed * Time.fixedDeltaTime, crouch, jump);
    }

    public void OnLanding()
    {
        jump = false;
        m_Animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool crouch)
    {
        m_Animator.SetBool("isCrouching", crouch);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
        m_Animator.SetFloat("HSpeed", Mathf.Abs(movement.x));
    }

    public void Jump()
    {
        jump = true;
        m_Animator.SetBool("isJumping", true);
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (!m_Animator.GetBool("isJumping"))
                SendMessage("PlayJump");
            Jump();
        }
    }

    public void OnCrouch(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
            crouch = true;
        else
        {
            crouch = false;
        }
    }

    public void OnHit(int damage)
    {
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Player_Hurt") && allowDamage)
        {
            allowDamage = false;
            Physics2D.IgnoreLayerCollision(6, 9);
            m_Animator.SetTrigger("TakeDamage");
            m_Animator.SetBool("isJumping", false);
            m_DamageReceived.Invoke(-damage);
            SendMessage("PlayHit");
        }
    }

    public void DamageReceived()
    {
        allowDamage = true;
        Physics2D.IgnoreLayerCollision(6, 9, false);
    }
}