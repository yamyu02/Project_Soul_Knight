    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int _health = 2;

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
    public void SetManaDropPercent(int percentage)
    {
        this._manaDropPercent = percentage;
    }
    public void SetCoinDropPercent(int percentage)
    {
        this._coinDropPercent = percentage;
    }
    public void SetNothingDropPercent(int percentage)
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
        Destroy(gameObject);
    }
}
