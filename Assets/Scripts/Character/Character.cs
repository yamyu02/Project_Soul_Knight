using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    private int _armor;
    private int _maxArmor;
    private int _mana;
    private int _coins;
    private bool _iFrame;
    

    [SerializeField]
    private float moveForce = 10f;
    private float movementx;
    private float movementy;

    [SerializeField]

    private SpriteRenderer sr;


    public Character()
    {
        
    }
    private void Awake()
    {   
        sr = GetComponent<SpriteRenderer>();
    }

    //---------------Getters and Setters---------------\\
    public void SetHealth(int health)
    {
        this._health = health; 
    }

    public void SetMaxHealth(int maxHealth)
    {
        this._maxHealth = maxHealth;
    }

    public void SetArmor(int armor)
    {
        this._armor = armor;
    }

    public void SetMaxArmor(int maxArmor)
    {
        this._maxArmor = maxArmor;
    }

    public void SetMana(int mana)
    {
        this._mana = mana;
    }

    public void SetiFrame(bool iframe)
    {
        this._iFrame = iframe;
    }

    public void SetMoveForce(int moveforce)
    {
        this.moveForce = moveforce;
    }

    public int GetHealth()
    {
        return this._health;
    }

    public int GetMaxHealth()
    {
        return this._maxHealth;
    }

    public int GetArmor()
    {
        return this._armor;
    }

    public int GetMaxArmor()
    {
        return this._maxArmor;
    }

    public int GetMana()
    {
        return this._mana;
    }

    public bool GetiFrame()
    {
        return this._iFrame;
    }

    //--------------------Methods--------------------\\
    public void Call()
    {
        PlayerMoveKeyboard();
        Face();
    }
    private void PlayerMoveKeyboard()
    {
        movementx = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveForce;

        movementy = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(0f, movementy, 0f) * Time.deltaTime * moveForce;
    }
    private void Face()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePosition - transform.position;


        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        else if (direction.x > 0)
        {
            sr.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            Debug.Log("Took hit");
            TakeDamage();
            CheckArmor();
        }
        if (other.gameObject.CompareTag("HealthPotion"))
        {
            this._health += 2;
            if (this._health > this._maxHealth)
            {
                this._health = this._maxHealth;
            }

            Debug.Log("Healed");
        }

        if (other.gameObject.CompareTag("ManaPotion"))
        {
            this._mana += 10;
            if (this._mana > 200)
            {
                this._mana = 200;
            }

            Debug.Log("Mana Regen");
        }

        if (other.gameObject.CompareTag("Coins"))
        {
            this._coins += 2;

            Debug.Log($"Coins: {_coins}");
        }
    }

            public void TakeDamage()
    {
        if (this._iFrame == false)
        {
            PlayerPrefs.SetInt("Damage", PlayerPrefs.GetInt("Damage", 0) + 1);
            if (this._armor > 0)
            {
                this._armor -= 1;
                Debug.Log($"Armor is {this._armor}");
            }

            else
            {
                this._health -= 1;
                Debug.Log($"Health is {this._health}");
                if (this._health < 1)
                {
                    PlayerPrefs.SetInt("Losses", PlayerPrefs.GetInt("Losses", 0) + 1);
                    Debug.Log("player is dead");
                }
            }
            this._iFrame = true;
            StartCoroutine(ResetIframe(0.5f));
        }
        else
        {
            Debug.Log("Character in IFrame");
        }
    }

    private IEnumerator ResetIframe(float delay)
    {
        yield return new WaitForSeconds(delay);
        this._iFrame = false;
    }

    private bool _armorRegen = false;
    public void CheckArmor()
    {
        if (this._armor < this._maxArmor && this._armorRegen == false)
        {
            this._armorRegen = true;
            StartCoroutine(RegenerateArmor(3f));
        }
        else
        {
            Debug.Log("Armor is full or is regnerating");
        }
    }

    private IEnumerator RegenerateArmor(float delay)
    {
        yield return new WaitForSeconds(delay);
        this._armor += 1;
        this._armorRegen = false;
        Debug.Log($"Armor Regenerated, Armor is {this._armor}");
        CheckArmor();
    }
}
