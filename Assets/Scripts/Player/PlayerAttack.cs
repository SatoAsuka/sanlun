using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int Boss3Damage;
    public int Boss1Damage;
    public int Boss2Damage;
    public int EnemyDamage;

    private BoxCollider2D Bc;
    // Start is called before the first frame update
    void Start()
    {
        Bc= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other ) 
    {
        if (other.CompareTag("Boss3"))
        {
            other.GetComponent<Boss3>().GetHurted(Boss3Damage);
        }
        if (other.CompareTag("Boss1"))
        {
            other.GetComponent<Boss1>().BeHit(Boss1Damage);
        }
        if (other.CompareTag("Boss2"))
        {
            other.GetComponent<Boss2>().Hurt(Boss2Damage);
        }
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(EnemyDamage);
        }
        if (other.CompareTag("EnemySkeleton"))
        {
            other.GetComponent<FSM>().TakeDamage();
        }
    }
    void Update()
    {
        
    }
}
