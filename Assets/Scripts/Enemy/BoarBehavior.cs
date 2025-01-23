using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoarBehavior : EnemyBase
{
    public Character character;
    public string SpawnRoom;
    private bool start = true;

    public float startTime;


    void Update()
    {
        if (SpawnRoom == character.CurrentRoom && start == true)
        {
            Call();
            start = false;
        }
    }
    private void Call()
    {

        base.SetPlayer(GameObject.FindWithTag("Player").transform);
        base.SetRb(GetComponent<Rigidbody2D>());
        base.SetSr(GetComponent<SpriteRenderer>());
        Face();
        StartCoroutine(GetPlayerPos(startTime));

    }

    private IEnumerator GetPlayerPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.SetDirection(base.GetPlayer().position - transform.position);
        base.SetCurrent(GetRb().velocity);
        StartCoroutine(ChargeReset(2f));
        base.SetRbVelocity(GetDirection() - GetCurrent());
        StartCoroutine(GetPlayerPos(3f)); 
    }

    private IEnumerator ChargeReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.SetRbVelocity(GetDirection() * 0);
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
                PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills", 0) + 1);

                character.SetMana(character.GetMana() + 20);
                if (character.GetMana() > 200)
                {
                    character.SetMana(200);
                }
                character.SetCoin(character.GetCoin() + 2);
                Destroy(gameObject);
            }
        }
    }

}
