using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFollow : MonoBehaviour
{
    private Vector3 tempPos;
    [SerializeField]
    private GameObject Enemy;

    void Update()
    {
        tempPos = transform.position;

        tempPos.x = Enemy.transform.position.x;
        tempPos.y = Enemy.transform.position.y;

        transform.position = tempPos;
    }
}
