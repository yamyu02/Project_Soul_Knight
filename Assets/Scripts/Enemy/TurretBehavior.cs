using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TurretBehavior : EnemyBase // not finished yet (most of this is still the boar code)
{
    public GameObject Bullet;
    public Transform BulletPos;
    public Character character;
    public string SpawnRoom;
    public float ShootDelay = 0;
    private float _shootTimer;

    void Start()
    {
        SetHealth(9999);
        base.SetPlayer(GameObject.FindWithTag("Player").transform);
        base.SetRb(GetComponent<Rigidbody2D>());
        base.SetSr(GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        if (SpawnRoom == character.CurrentRoom)
        {
            _shootTimer += Time.deltaTime;
            if (_shootTimer > ShootDelay)
            {
                _shootTimer = 0;
                Instantiate(Bullet, BulletPos.position, Quaternion.identity);
            }
        }
    }

    private IEnumerator BulletSpread(int n) // this is named bulletspread because i changed it from something else
    {
        for (int i = 0; i < n; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Bullet, BulletPos.position, Quaternion.identity);
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
