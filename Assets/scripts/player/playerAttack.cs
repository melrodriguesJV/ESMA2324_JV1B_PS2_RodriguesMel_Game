using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform meleePoint;
    [SerializeField] private float meleeRange;
    [SerializeField] private LayerMask enemyLayer;

    private Animator anim;
    private playerMoves playerMoves;
    private batPowerup bat;
    private health hp;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMoves = GetComponent<playerMoves>();
        bat = GetComponent<batPowerup>();
        hp = GetComponent<health>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMoves.canAttack())
            Attack();

        if (Input.GetKeyDown(KeyCode.B) && cooldownTimer > attackCooldown && playerMoves.canAttack())
            Melee();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void Melee()
    {
        if (bat.pick == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange, enemyLayer);

            foreach(Collider2D enemy in hitEnemies)
            {
                hp.TakeDamage(1);
            }
        }
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        
        return 0;
    }
}
