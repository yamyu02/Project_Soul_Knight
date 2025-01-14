using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSAM : MonoBehaviour
{
    public int movementx = 1;
    public int moveForce = 5;
    [SerializeField]
    private SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        StartCoroutine(switchDirection(5f));
    }
    void Update()
    {
        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private IEnumerator switchDirection(float delay)
    {
        yield return new WaitForSeconds(delay);
        movementx *= -1;
        if (movementx == -1)
        {
            sr.flipX = true;
        }
        else if (movementx == 1)
        {
            sr.flipX = false;
        }
        StartCoroutine(switchDirection(5f));
    }
}
