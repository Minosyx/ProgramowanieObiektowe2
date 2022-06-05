
using UnityEngine;

public class Enemy : MonoBehaviour {

    public virtual void IgnoreCollisions(GameObject obj)
    {
        Physics2D.IgnoreLayerCollision(obj.layer, obj.layer);
    }
    public virtual void CollisionOcurred(Collision2D collision, Animator m_Animator, int m_Damage, float hitRange)
    {
        if (collision.collider.name == "Player"
            && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Death")
            && !m_Animator.GetCurrentAnimatorStateInfo(1).IsName("Blink"))
        {
            var point = collision.contacts[0].normal;
            if (point.y < -hitRange)
            {
                transform.parent.parent.SendMessage("TakeDamage", this);
                collision.gameObject.SendMessage("Launch");
            }
            else
                collision.gameObject.SendMessage("OnHit", m_Damage);
        }
        else if (collision.collider.name == "Player")
            collision.gameObject.SendMessage("Launch");
    }
}

