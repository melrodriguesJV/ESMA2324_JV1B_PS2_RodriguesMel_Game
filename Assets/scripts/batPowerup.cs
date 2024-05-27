using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batPowerup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        player.GetComponent<playerAttack>().picked = true;
        Destroy(gameObject);
    }
}
