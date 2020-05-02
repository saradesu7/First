using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject attack;
    
    public void Attack()
    {
        Instantiate(attack, firePoint.position, firePoint.rotation);
    }
}
