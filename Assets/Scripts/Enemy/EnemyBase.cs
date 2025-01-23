using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private Transform player;
    private Vector3 direction;
    private Vector3 Current;
    private Vector3 Pos;
    private int _health = 5;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer sr;

    public Transform GetPlayer()
    {
        return player;
    }

    public void SetPlayer(Transform p)
    {
        this.player = p;
    }
    public Vector3 GetDirection()
    {
        return direction;
    }

    public void SetDirection(Vector3 d)
    {
        this.direction = d;
    }

    public Vector3 GetCurrent()
    {
        return Current;
    }

    public void SetCurrent(Vector3 c)
    {
        this.Current = c;
    }

    public Vector3 GetPos()
    {
        return Pos;
    }

    public void SetPos(Vector3 p)
    {
        this.Pos = p;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int h)
    {
        this._health = h;
    }

    public Rigidbody2D GetRb()
    {
        return rb;
    }

    public void SetRb(Rigidbody2D r)
    {
        this.rb = r;
    }

    public void SetRbVelocity(Vector3 r) // this might be unnecessary in practice but it's a bit easier to use
    {
        this.rb.velocity = r;
    }

    public SpriteRenderer GetSr()
    {
        return sr;
    }

    public void SetSr(SpriteRenderer s)
    {
        this.sr = s;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
