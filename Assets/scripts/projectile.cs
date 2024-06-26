using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreLayerCollision(10, 11, true); // pas de collisions avec les collectibles
        Physics2D.IgnoreLayerCollision(10, 12, true); // pas de collsions avec les cam�ras
        Physics2D.IgnoreLayerCollision(10, 10, true); // pas de collsions avec les autres munitions
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        Deactivate();

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<enemyHealth>().TakeDamage(1);
        }
            
       
        if (collision.tag == "Robot")
        {
            collision.GetComponent<enemyHealth>().TakeDamage(0);
        }
            
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
