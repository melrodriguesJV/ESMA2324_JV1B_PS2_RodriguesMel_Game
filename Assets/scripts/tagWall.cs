using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tagWall : MonoBehaviour
{
    [SerializeField] private int value;
    public bool playerIsClose;
    private SpriteRenderer spriteRend;
    private PointManager pointManager;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        pointManager = PointManager.instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            spriteRend.color = Color.red;
            pointManager.ChangePoints(value);
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
