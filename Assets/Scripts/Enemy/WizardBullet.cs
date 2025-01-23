using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardBullet : MonoBehaviour
{
    public GameObject Sprite;
    public GameObject Player;
    private Rigidbody2D rb;
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // so the velocity can be adjusted
        Player = GameObject.FindGameObjectWithTag("Player"); // so that the player can be referenced in code

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Wall") || coll.gameObject.CompareTag("Box"))
        {
            // Debug.Log("wall collide");
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            // Debug.Log("Player collide");
            Destroy(gameObject);
        }
    }
}
