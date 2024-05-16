using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currenthealth;

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
        }
    }
}
