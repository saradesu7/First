using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtandDestroy : MonoBehaviour
{
    private int Counter = 1;
    [SerializeField] private Animator m_animator;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Counter++;
        m_animator.Play("Hurt", -1, 0f);
        if (Counter > 3)
        {
            m_animator.Play("ArcherDie", -1, 0f);
            Destroy(gameObject);
        }
    }
}
