using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private Transform player;
    public float OffSetX;
    public float OffSetY;
    private int _direction = 1;
    private Vector3 tempPos;
    private float movementx;
    private bool _throwing = false;

    public string Type;
    public WeaponTypeManager CurrentType; 


    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Throw ();
        Rotate();
        tempPos = transform.position;
        tempPos.x = player.position.x + OffSetX * _direction;
        tempPos.y = player.position.y - OffSetY;
        transform.position = tempPos;

    }

    //Help from AI

    private void Rotate()
    {
        if (this._throwing == false)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Calculate the direction from the object to the mouse
            Vector3 direction = mousePosition - transform.position;

            // Ignore Z-axis to make this work in 2D
            direction.z = 0;

            // Rotate the object to face the mouse
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Flip the sprite horizontally based on the X direction
            if (direction.x < 0) // Mouse is to the left of the object
            {
                spriteRenderer.flipY = true;
                this._direction = -1;
            }
            else if (direction.x > 0) // Mouse is to the right of the object
            {
                spriteRenderer.flipY = false;
                this._direction = 1;
            }
        }
    }

    private void Throw()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (this.Type == CurrentType.CurrentType)
            {
                this._throwing = true;
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                if (direction.x < 0)
                {
                    StartCoroutine(SmoothRotate(angle, angle + 50, 0.1f));
                }
                else if (direction.x > 0)
                {
                    StartCoroutine(SmoothRotate(angle, angle - 50, 0.1f));
                }

                
                StartCoroutine(ResetPosition(0.1f));
            }
        }
    }


    //Help From Ai
    private IEnumerator SmoothRotate(float startAngle, float targetAngle, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float currentAngle = Mathf.Lerp(startAngle, targetAngle, elapsed / duration); // Interpolate between start and target angle
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle); // Apply rotation
            yield return null; // Wait for the next frame
        }

        transform.rotation = Quaternion.Euler(0f, 0f, targetAngle); // Ensure the final angle is set
    }


    private IEnumerator ResetPosition(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (this.Type == "Mary")
        {
            CurrentType.CurrentType = "Jack";
        }
        else
        {
            CurrentType.CurrentType = "Mary";
        }
        this._throwing = false;
        
    }

}
