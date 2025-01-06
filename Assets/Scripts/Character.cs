using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _health;
    private int _armor;
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

    public void SetArmor(int armor)
    {
        this._armor = armor;
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

    public int GetArmor()
    {
        return this._armor;
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
}
