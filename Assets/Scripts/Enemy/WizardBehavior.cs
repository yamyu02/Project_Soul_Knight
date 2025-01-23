using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehavior : EnemyBase // not finished yet (most of this is still the boar code)
{
    public float startTime;
    void Start()
    {

        base.SetPlayer(GameObject.FindWithTag("Player").transform);
        base.SetRb(GetComponent<Rigidbody2D>());
        base.SetSr(GetComponent<SpriteRenderer>());
        Face();
        StartCoroutine(GetPlayerPos(startTime));

    }

    void Update()
    {
        if (Vector3.Distance(base.GetPlayer().position, transform.position) > 7.2)
        {
            base.SetRbVelocity(GetDirection() - GetCurrent());
        }
        else if (Vector3.Distance(base.GetPlayer().position, transform.position) < 6.8)
        {
            base.SetRbVelocity(-(GetDirection() - GetCurrent()));
        }
    }

    private IEnumerator GetPlayerPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.SetDirection(GetPlayer().position - transform.position);
        //Current = rb.velocity;
        base.SetCurrent(GetRb().velocity * 0);
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
        base.SetPos(transform.position);

        if (base.GetPos().x > base.GetPlayer().position.x)
        {
            base.GetSr().flipX = true;
        }
        if (base.GetPos().x < base.GetPlayer().position.x)
        {
            base.GetSr().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            base.SetHealth(base.GetHealth() - 1);
            if (base.GetHealth() < 1)
            {
                Destroy(gameObject);
            }
        }
    }

}
