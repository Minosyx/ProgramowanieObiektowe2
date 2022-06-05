using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public void TakeDamage(IEnemy obj)
    {
        if (!obj.GetAnimator.GetCurrentAnimatorStateInfo(1).IsName("Blink"))
        {
            obj.Lifes--;
            if (obj.Lifes == 0)
                Die(obj);
            else
                obj.GetAnimator.SetTrigger("Blink");
        }
    }

     private void Die(IEnemy obj)
    {
        obj.GetAnimator.SetTrigger("Die");
    }
}
