using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Staff : MonoBehaviour
{
    private Vector3 tempPos;
    private Transform player;
    public float OffSetX;
    public float OffSetY;
    private int _manaCost = 2;
    public Character character;
    private int _direction = 1;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Face();
        tempPos = transform.position;
        tempPos.x = player.position.x + OffSetX * _direction;
        tempPos.y = player.position.y - OffSetY;
        transform.position = tempPos;
        if (character.GetHealth() < 1)
        {
            Destroy(gameObject);
        }
    }

    private void Face()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mousePosition - transform.position;


        if (direction.x < 0)
        {
            this._direction = -1;
        }
        else if (direction.x > 0)
        {
            this._direction = 1;
        }
    }
}
