using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private int damage;
    private health playerHealth;
    private bool zoned;

    private void Start()
    {
        zoned = false;
        playerHealth = GetComponent<health>();
    }

    private void Update()
    {
        if (zoned)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            zoned = true;
        }
    }
}
