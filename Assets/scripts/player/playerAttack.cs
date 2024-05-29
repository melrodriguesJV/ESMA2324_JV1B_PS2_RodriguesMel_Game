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

    public bool picked;
    private Animator anim;
    private playerMoves playerMoves;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        picked = false;
        anim = GetComponent<Animator>();
        playerMoves = GetComponent<playerMoves>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMoves.canAttack())
            Attack();

        if (Input.GetKeyDown(KeyCode.B) && cooldownTimer > attackCooldown && playerMoves.canAttack() && picked)
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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleePoint.position, meleeRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyHealth>().TakeDamage(1);
        }
    
    }

    private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
            return; //éviter des bugs

        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
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
