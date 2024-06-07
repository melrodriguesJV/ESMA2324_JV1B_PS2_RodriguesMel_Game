using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointSprite : MonoBehaviour
{
    private SpriteRenderer spriteRend;
    [SerializeField] private Sprite active;
    public bool playerIsClose;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerIsClose)
        {
            spriteRend.sprite = active;

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
