using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : MonoBehaviour
{
    [SerializeField]private Animator m_ThisAnimator;
    [SerializeField]private float m_speed = 5.0f;
    public Archer archer;
    public SmAttack smattack;
    public CastleDestroy castle;
    [SerializeField] private Transform firePoint;
    private static int count = 1;
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, Vector3.left, 10f, GetFinalLayerMask(8,12));
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
             //   Debug.Log(hit.transform.name);
                smattack.Attack();
                m_ThisAnimator.Play("SmAttack");
                if(!m_ThisAnimator.GetBool("IsAttacking"))
                    m_ThisAnimator.SetBool("IsAttacking", true);
            }
            if(castle != null)
            {
             //   Debug.Log(hit.transform.name);
                smattack.Attack();
                m_ThisAnimator.Play("SmAttack");
                if (!m_ThisAnimator.GetBool("IsAttacking"))
                    m_ThisAnimator.SetBool("IsAttacking", true);
            }
        }
        else
        {
            if (m_ThisAnimator.GetBool("IsAttacking"))
                m_ThisAnimator.SetBool("IsAttacking", false);
            transform.position += Vector3.left * m_speed * Time.deltaTime;

            m_ThisAnimator.Play("SmRun");
            transform.localScale = new Vector3(1, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (count < 5)
            count++;
        else
            Destroy(gameObject);
    }

    private int GetFinalLayerMask(int ArcherLayer, int CastleLayer)
    {
        int layer1 = 1 << 8;
        int layer2 = 1 << 12; 
        return layer1 | layer2;
    }       
}
