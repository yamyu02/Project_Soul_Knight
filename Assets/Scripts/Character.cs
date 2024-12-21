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


    public Character(int health, int armor)
    {
        _health = health;
        _armor = armor;
        _mana = 200;
        _coins = 0;
        _iFrame = false;
    }
    private void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetHealth(int health)
    {
        this._health = health; 
    }

    public void SetArmor(int armor)
    {
        this._armor = armor;
    }
    public int GetHealth()
    {
        return this._health;
    }

    public int GetArmor()
    {
        return this._armor;
    }

    public void SetiFrame(bool iframe)
    {
        this._iFrame = iframe;
    }

    public void SetMoveForce(int moveforce)
    {
        this.moveForce = moveforce;
    }
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
        if (movementx > 0)
        {
            sr.flipX = false;
        }
        else if (movementx < 0)
        {
            sr.flipX = true;
        }
    }
}
