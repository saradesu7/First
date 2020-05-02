using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float m_MIn;
    [SerializeField] private float m_Max;
   
    IEnumerator Start()
    {
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(m_MIn, m_Max));
        Instantiate(gameObject, null);
    }
         

}
