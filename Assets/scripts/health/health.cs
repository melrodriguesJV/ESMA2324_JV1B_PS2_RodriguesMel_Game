using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }
    private bool dead;

    private void Awake()
    {
        currenthealth = startingHealth;
    }

    public void TakeDamage (float _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startingHealth);

        if (currenthealth > 0)
        {
            //hurt
        }
        else
        {
            //dead
            if (!dead)
            {
                GetComponent<playerMoves>().enabled = false;
                dead = true;
            }
        }
    }

    private void Update()
    {
        
    }
}
