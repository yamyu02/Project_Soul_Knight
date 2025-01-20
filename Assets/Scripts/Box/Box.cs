    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int _health = 2;

    public GameObject HealthPotion;
    public GameObject ManaPotion;
    public GameObject Coins;

    private int _hpDropPercent;
    private int _manaDropPercent;
    private int _coinDropPercent; 
    private int _nothingDropPercent; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHpDrop(int percentage)
    {
        this._hpDropPercent = percentage;
    }
    public void SetManaDrop(int percentage)
    {
        this._manaDropPercent = percentage;
    }
    public void SetCoinDrop(int percentage)
    {
        this._coinDropPercent = percentage;
    }
    public void SetNothingDrop(int percentage)
    {
        this._nothingDropPercent = percentage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Break();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            this._health -= 1;

            if (this._health < 0)
            {
                Break();
            }
        }
    }

    private void Break()
    {
        RollDrop();
        Destroy(gameObject);
    }

    private void RollDrop() //Help from Ai
    {
        int randomValue = Random.Range(1, 101); 

        if (randomValue <= _hpDropPercent)
        {
            Instantiate(HealthPotion, transform.position, Quaternion.identity);
        }
        else if (randomValue <= _hpDropPercent + _manaDropPercent)
        {
            Instantiate(ManaPotion, transform.position, Quaternion.identity);
        }
        else if (randomValue <= _hpDropPercent + _manaDropPercent + _coinDropPercent)
        {
            Instantiate(Coins, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nothing dropped.");
        }
    }
}
