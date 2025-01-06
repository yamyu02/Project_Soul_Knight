using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarBehavior : MonoBehaviour
{
    private Transform player;
    private Vector3 direction;
    [SerializeField]
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(GetPlayerPos(3f));

    }

    private IEnumerator GetPlayerPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        direction = player.position - transform.position;
        StartCoroutine(ChargeReset(2f));
        rb.velocity = direction * 2;
        StartCoroutine(GetPlayerPos(3f)); 
    }

    private IEnumerator ChargeReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = direction * 0;
    } 
}
