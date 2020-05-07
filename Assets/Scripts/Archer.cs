using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Archer : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Animator m_ThisAnimator;
    [SerializeField] private float m_speed;
    private int HPcount = 0;
    private bool m_facingRight = true;

    List<GameObject> arrowlist;

    private void Start()
    {
        arrowlist = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject objarrow = (GameObject)Instantiate(arrow);
            objarrow.SetActive(false);
            arrowlist.Add(objarrow);
        }
    }

    void FixedUpdate()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            m_ThisAnimator.Play("ArcherAttack", -1, 0f);
            Create();
        }
        if (HPcount >= 20)
        {
            gameManager.Score -= 100f;
            Destroy(gameObject);
        }
        Debug.Log(HPcount);
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
        gameManager.Score -= 5f;
    }

    private void Create()
    {
        for (int i = 0; i < arrowlist.Count; i++)
        {
            if (!arrowlist[i].activeInHierarchy)
            {
                arrowlist[i].transform.position = firePoint.position;
                arrowlist[i].transform.rotation = firePoint.rotation;
                arrowlist[i].SetActive(true);
                break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HPcount++;
    }
    /* public void OnChangeScore(int Score)
     {
         m_Score = Score;
     }*/
}
