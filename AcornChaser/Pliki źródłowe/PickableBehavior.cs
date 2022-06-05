using UnityEngine;
using UnityEngine.Events;

public class PickableBehavior : MonoBehaviour, IPickable
{
    private Animator m_PickableAnimator;

    private bool started = false;

    public GameObject GetSelf => gameObject;

    private void Awake()
    {
        m_PickableAnimator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if (!started && player.name == "Player")
        {
            if (tag == "PHeart" && GameSystem.Instance.playerHealth == 5)
                return;
            started = true;
            m_PickableAnimator.SetTrigger("Obtain");
        }
    }
}
