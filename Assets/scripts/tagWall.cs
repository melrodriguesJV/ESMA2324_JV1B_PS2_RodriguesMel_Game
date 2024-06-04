using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tagWall : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private Sprite covered;
    public bool playerIsClose;
    private SpriteRenderer spriteRend;
    private PointManager pointManager;
    private bool check;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        check = false;
    }

    private void Start()
    {
        pointManager = PointManager.instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && check == false)
        {
            spriteRend.sprite = covered; // change l'apparence du mur
            pointManager.ChangePoints(value); // ajoute des points au score
            check = true;
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
