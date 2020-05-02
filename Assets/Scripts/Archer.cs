using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Archer : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Animator m_ThisAnimator;
    [SerializeField] private float m_speed;
    [SerializeField] private static float HP = 100f;
    private bool m_facingRight = true;
    private int count = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Callarrow();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * m_speed * Time.deltaTime;
            if(!m_facingRight)
                flip();
            if (m_ThisAnimator.GetBool("NotRunning"))
            {
                m_ThisAnimator.SetBool("NotRunning", false);
                m_ThisAnimator.Play("Run", -1, 0f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopRun();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * m_speed * Time.deltaTime;
            if (m_facingRight)
                flip();
            if (m_ThisAnimator.GetBool("NotRunning"))
            {
                m_ThisAnimator.Play("Run", -1, 0f);
                m_ThisAnimator.SetBool("NotRunning", false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopRun();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_ThisAnimator.Play("ArcherAttack", -1, 0f);
            if (count <= 3)
            {
                Instantiate(arrow, firePoint.position, firePoint.rotation);
                count++;
            }
            else
                count = 0;
        }
        if (HP == 0)
            Destroy(gameObject);
    }

    private void StopRun()
    {
        m_ThisAnimator.SetBool("NotRunning", true);
        m_ThisAnimator.Play("Idle", -1, 0f);
    }

    void flip()
    {
        m_facingRight = !m_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Damage()
    {
        HP = HP - 5f;
    }
}
