using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private health playerHealth;
    private bool check;

    private void Awake()
    {
        check = false;
        playerHealth = GetComponent<health>();
    }

    private void Update()
    {
        if (playerHealth.dead == true && check == false)
        {
            Respawn();
            check = true;
        }

        if (check == true)
            playerHealth.crossed = true;
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
        
    }
}
