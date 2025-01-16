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

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 7.2)
        {
            rb.velocity = direction - Current;
        }
        else if (Vector3.Distance(player.position, transform.position) < 6.8)
        {
            rb.velocity = -(direction - Current);
        }
    }

    private IEnumerator GetPlayerPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        direction = player.position - transform.position;
        //Current = rb.velocity;
        Current = rb.velocity * 0;
        StartCoroutine(ChargeReset(2f));
        //rb.velocity = direction - Current;
        StartCoroutine(GetPlayerPos(3f)); 
    }

    private IEnumerator ChargeReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        //rb.velocity = direction * 0;
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
