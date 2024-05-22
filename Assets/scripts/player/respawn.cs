using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<health>();
    }
}
