using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WizardBehavior : EnemyBase // not finished yet (most of this is still the boar code)
{
    public GameObject Bullet;
    public Transform BulletPos;
    public Character character;
    private string SpawnRoom = "Room2";
    public float startTime;
    public float ShootDelay = 0;
    private float _shootTimer;
    private int _shotsFired;
    public float Speed;

    public GameObject WinMenu;
    public AudioSource WinAudio;

    void Start()
    {
        SetHealth(50);
        base.SetPlayer(GameObject.FindWithTag("Player").transform);
        base.SetRb(GetComponent<Rigidbody2D>());
        base.SetSr(GetComponent<SpriteRenderer>());
        Face();
        // StartCoroutine(GetPlayerPos(startTime));
    }

    void Update()
    {
        if (SpawnRoom == character.CurrentRoom)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, GetPlayer().transform.position, Speed * Time.deltaTime);
            _shootTimer += Time.deltaTime;
            //if (Vector3.Distance(base.GetPlayer().position, transform.position) > 7.2)
            //{
            //    base.SetRbVelocity(GetDirection() - GetCurrent());
            //}
            //else if (Vector3.Distance(base.GetPlayer().position, transform.position) < 6.8)
            //{
            //    base.SetRbVelocity(-(GetDirection() - GetCurrent()));
            //}
            if (_shootTimer > ShootDelay)
            {
                _shootTimer = 0;
                _shotsFired += 1;
                Instantiate(Bullet, BulletPos.position, Quaternion.identity);
            }
            if (_shotsFired > 8)
            {
                _shotsFired = 0;
                BulletSpread(5);
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

    //private IEnumerator GetPlayerPos(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    base.SetDirection(GetPlayer().position - transform.position);
    //    //Current = rb.velocity;
    //    base.SetCurrent(GetRb().velocity * 0);
    //    StartCoroutine(ChargeReset(2f));
    //    //rb.velocity = direction - Current;
    //    StartCoroutine(GetPlayerPos(3f)); 
    //}

    //private IEnumerator ChargeReset(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    //rb.velocity = direction * 0;
    //    base.Face();
    //}
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            base.SetHealth(base.GetHealth() - 1);
            if (base.GetHealth() < 1)
            {
                WinAudio.Play();
                WinMenu.SetActive(true); // you can still use p to unpause here but i don't really care about that
                Time.timeScale = 0;
                PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins", 0) + 1);
                Destroy(gameObject);
            }
        }
    }

}
