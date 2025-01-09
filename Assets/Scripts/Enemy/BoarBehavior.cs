    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarBehavior : MonoBehaviour
{
    private Transform player;
    private Vector3 direction;
    private Vector3 Current;
    private Vector3 BoarPos;
    private int _health = 5;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer sr;

    public float startTime;
    void Start()
    {

        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Face();
        StartCoroutine(GetPlayerPos(startTime));

    }

    private IEnumerator GetPlayerPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        direction = player.position - transform.position;
        Current = rb.velocity;
        StartCoroutine(ChargeReset(2f));
        rb.velocity = direction - Current;
        StartCoroutine(GetPlayerPos(3f)); 
    }

    private IEnumerator ChargeReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = direction * 0;
        Face();
    }
    
    private void Face()
    {
        BoarPos = transform.position;

        if (BoarPos.x > player.position.x)
        {
            sr.flipX = true;
        }
        if (BoarPos.x < player.position.x)
        {
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            this._health -= 1;
            if (this._health < 1)
            {
                Destroy(gameObject);
            }
        }
    }

}
