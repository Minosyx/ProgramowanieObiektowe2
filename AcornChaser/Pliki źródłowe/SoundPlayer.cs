using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource m_AudioSource;

    public AudioClip m_JumpClip;

    public AudioClip m_HitClip;

    [Range(0, 1f)] public float m_Volume = 1f;

    public void PlayHit()
    {
        m_AudioSource.PlayOneShot(m_HitClip, m_Volume);
    }

    public void PlayJump()
    {
        m_AudioSource.PlayOneShot(m_JumpClip, m_Volume);
    }
}
