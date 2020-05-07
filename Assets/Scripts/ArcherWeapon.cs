using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip hit;
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(hit, transform.position);
        gameObject.SetActive(false);
    }
}
