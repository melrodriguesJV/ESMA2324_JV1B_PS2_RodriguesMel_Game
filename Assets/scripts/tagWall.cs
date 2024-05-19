using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tagWall : MonoBehaviour
{
    public bool playerIsClose;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            spriteRend.color = Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
}
