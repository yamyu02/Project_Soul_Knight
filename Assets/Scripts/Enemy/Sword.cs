using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EnemyBase
{
    public Character character;
    public EnemyBase enemy;
    public string SpawnRoom;
    private bool start = true;
    private Transform player;
    private Vector3 tempPos;

    public float startTime;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SetHealth(10);
    }
    void Update()
    {
        if (enemy.GetHealth() == 0)
        {
            Destroy(gameObject);
        }
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
        
        StartCoroutine(GetPlayerPos(startTime));

    }

    private IEnumerator GetPlayerPos(float delay)
    {
        Face();
        yield return new WaitForSeconds(delay);
        base.SetDirection(base.GetPlayer().position - transform.position);
        base.SetCurrent(GetRb().velocity);
        StartCoroutine(ChargeReset(1.5f));
        base.SetRbVelocity(GetDirection() - GetCurrent());
        StartCoroutine(GetPlayerPos(5f));
    }

    private IEnumerator ChargeReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        base.SetRbVelocity(GetDirection() * 0);
    }

    public override void Face()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        // Calculate the direction from the object to the mouse
        Vector3 direction = tempPos - transform.position;

        // Ignore Z-axis to make this work in 2D
        direction.z = 0;

        // Rotate the object to face the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            base.SetHealth(base.GetHealth() - 1);
            if (base.GetHealth() < 1)
            {
                PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills", 0) + 1);

                character.SetMana(character.GetMana() + 50);
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
