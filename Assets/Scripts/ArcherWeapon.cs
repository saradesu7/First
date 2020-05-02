using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
