using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehavior : MonoBehaviour // not finished yet (most of this is still the boar code)
{
    private Transform player;
    private Vector3 direction;
    private Vector3 Current;
    private Vector3 WizardPos;
    private int _health = 50; // i have no idea how much health this guy actually has
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
        if (Vector3.Distance(player.position, transform.position) > 3)
        {
            // Debug.Log($"distance: {Vector3.Distance(player.position, transform.position)}");
        }
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
        WizardPos = transform.position;

        if (WizardPos.x > player.position.x)
        {
            sr.flipX = true;
        }
        if (WizardPos.x < player.position.x)
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
