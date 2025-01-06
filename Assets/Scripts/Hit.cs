using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit");

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
            Destroy(gameObject);
        }

    }
}