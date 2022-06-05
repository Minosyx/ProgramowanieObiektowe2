using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DeleteObject : StateMachineBehaviour
{
    [SerializeField] private AudioClip m_DeathSound;
    [SerializeField] private float m_Volume = 1f;
    private AudioSource m_AudioSource;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var obj = animator.GetComponent<IEnemy>().GetSelf;
        Destroy(obj);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        var obj = animator.GetComponent<IEnemy>();
        m_AudioSource = obj.GetSelf.GetComponent<AudioSource>();
        m_AudioSource.PlayOneShot(m_DeathSound, m_Volume);
        obj.CanMove = false;
    }
}
