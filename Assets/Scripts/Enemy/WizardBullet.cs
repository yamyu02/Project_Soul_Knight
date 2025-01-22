using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardBullet : MonoBehaviour
{
    public GameObject Sprite;
    public float MoveSpeed;
    public float StartingXDirection;
    public float StartingYDirection;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(StartingXDirection, StartingYDirection, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * MoveSpeed;
        Sprite.transform.Rotate(Vector3.forward * -1);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            Debug.Log("wall collide");
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collide");
            Destroy(gameObject);
        }
    }
}
