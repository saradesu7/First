using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Archer archer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip hit;
    private void Start()
    {
        rb.velocity = Vector3.left * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == 8) //archerlayer
        {
            archer.Damage();
        }
        Debug.Log(collision.collider.gameObject.layer);
        AudioSource.PlayClipAtPoint(hit, transform.position);
        Destroy(gameObject);
    }
}
