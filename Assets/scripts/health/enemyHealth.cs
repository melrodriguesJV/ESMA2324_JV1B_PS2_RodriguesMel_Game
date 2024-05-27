using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        currenthealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(dead == true)
            Deactivate();
    }

    public void TakeDamage(float _damage)
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
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
            }
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
