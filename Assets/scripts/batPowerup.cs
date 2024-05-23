using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batPowerup : MonoBehaviour
{
    public bool pick;

    private void Awake()
    {
        pick = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
            pick = true;
        }
    }
}
