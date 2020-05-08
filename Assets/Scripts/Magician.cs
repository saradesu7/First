using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    [SerializeField] private Animator m_ThisAnimator;
    [SerializeField] private float m_speed = 5.0f;
    public Archer archer;
    public CastleDestroy castle;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject attack;
    public int count = 0;

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector3.left, 10f, GetFinalLayerMask(8, 12));
        Debug.DrawRay(firePoint.position, Vector3.left * 10f, Color.black);
        ifhit(hit);
    }

    void ifhit(RaycastHit2D hit)
    {
        if (hit)
        {
            archer = hit.transform.GetComponent<Archer>();
            castle = hit.transform.GetComponent<CastleDestroy>();
            if (archer != null)
            {
                if (Time.time % 0.5 == 0)
                {
                    Instantiate(attack, firePoint.position, firePoint.rotation);
                    //archer.Damage();
                }
            }
            if (castle != null)
                if (Time.time % 0.5 == 0)
                    Instantiate(attack, firePoint.position, firePoint.rotation);
            m_ThisAnimator.Play("MgAttack");
            if (!m_ThisAnimator.GetBool("IsAttacking"))
                m_ThisAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            if (m_ThisAnimator.GetBool("IsAttacking"))
                m_ThisAnimator.SetBool("IsAttacking", false);
            transform.position += Vector3.left * m_speed * Time.deltaTime;

            m_ThisAnimator.Play("MgRun");
            transform.localScale = new Vector3(1.3f, 1.3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.Score += 10f;
        if (count < 20)
            count++;
        else
        {
            gameObject.SetActive(false);
            count = 0;
        }
    }

    private int GetFinalLayerMask(int ArcherLayer, int CastleLayer)
    {
        int layer1 = 1 << 8;
        int layer2 = 1 << 12;
        return layer1 | layer2;
    }
}
