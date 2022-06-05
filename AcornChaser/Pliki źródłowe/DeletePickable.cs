using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePickable : StateMachineBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    public AudioClip m_Obtain;

    [SerializeField] private float m_Volume = 1f;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var obj = animator.GetComponent<IPickable>().GetSelf;
        Destroy(obj);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var obj = animator.GetComponent<IPickable>().GetSelf;
        m_AudioSource = obj.GetComponent<AudioSource>();
        m_AudioSource.PlayOneShot(m_Obtain, m_Volume);
        if (obj.tag == "Acorn")
            GameSystem.Instance.AcornsLeft();
        else if (obj.tag == "PHeart")
        {
            obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameSystem.Instance.OnHealthChange(1);
        }
    }
}
