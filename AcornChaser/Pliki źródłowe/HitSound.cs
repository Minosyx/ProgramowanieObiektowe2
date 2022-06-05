using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : StateMachineBehaviour
{
    [SerializeField] private AudioClip m_HitSound;
    [SerializeField] private float m_Volume = 1f;
    private AudioSource m_AudioSource;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var obj = animator.GetComponent<IEnemy>();
        m_AudioSource = obj.GetSelf.GetComponent<AudioSource>();
        m_AudioSource.PlayOneShot(m_HitSound, m_Volume);
    }
}
