using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityCam : MonoBehaviour
{
    [SerializeField] private GameObject mob_1;
    public bool playerIsClose;

    private void Update()
    {
        if (playerIsClose)
        {
            mob_1.SetActive(true);
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
