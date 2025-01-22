using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject _daggerPrefab; 

    public Character character;

    private Transform player;
    public float OffSetX;
    public float OffSetY;
    private int _direction = 1;
    private Vector3 tempPos;
    private float movementx;
    private bool _throwing = false;

    private int _manaCost = 2;

    public string Type;
    public WeaponTypeManager CurrentType;
 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Throw ();
        Rotate();
        tempPos = transform.position;
        tempPos.x = player.position.x + OffSetX * _direction;
        tempPos.y = player.position.y - OffSetY;
        transform.position = tempPos;
        if (character.GetHealth() < 1)
        {
            Destroy(gameObject);
        }

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
            if (this.Type == CurrentType.CurrentType && character.GetMana() > 0)
            {
                ManaUse();
                this._throwing = true;

                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                Vector3 direction = (mousePosition - transform.position).normalized;

                // Help From Ai--------------------------------------------------------------------------\\
                GameObject dagger = Instantiate(_daggerPrefab, transform.position, Quaternion.identity);
                SpriteRenderer daggerSpriteRenderer = dagger.GetComponent<SpriteRenderer>();

                if (direction.x < 0)
                {
                    daggerSpriteRenderer.flipY= true;
                }
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                dagger.transform.rotation = Quaternion.Euler(0f, 0f, angle); // Normal rotation

                Rigidbody2D rb = dagger.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float daggerSpeed = 100f; // Adjust the speed as needed
                    rb.velocity = direction * daggerSpeed;
                }
                Destroy(dagger, 2f);
                // -----------------------------------------------------------------------------------------\\

                if (direction.x < 0)
                {
                    StartCoroutine(SmoothRotate(angle, angle + 75, 0.1f));
                }
                else if (direction.x > 0)
                {
                    StartCoroutine(SmoothRotate(angle, angle - 75, 0.1f));
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

    private void ManaUse()
    {
        int CalcMana = character.GetMana() - this._manaCost;
        character.SetMana(CalcMana);
        Debug.Log(character.GetMana());
    }
}
