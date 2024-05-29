using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falliingTile : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            body.gravityScale = 1;
        }
    }
}
