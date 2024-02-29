using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    GameObject Boss;
    Animator animator;
    Collider2D collider2d;

    Vector3 dir;

    public float Speed;

    public int Damge;

    public float LifeTime;

    void Start()
    {
        Boss = GameObject.Find("Boss1");
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        dir = transform.localScale;

        Speed = 5;

        Damge = 8;

        LifeTime = 7f;
    }

    void Update()
    {
        Move();
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0 || Boss.GetComponent<Boss1>().isDead)
        {
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        if (Boss.transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(dir.x, dir.y, dir.z);
            transform.position += Speed * -transform.right * Time.deltaTime;
        }
        else if (Boss.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-dir.x, dir.y, dir.z);
            transform.position += Speed * transform.right * Time.deltaTime;
        }
    }
    public void CloseCollider()
    {
        collider2d.enabled = false;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.Play("Hit");

            // 获取攻击力（damage）为火球的伤害值
            int damage = Damge;

            // 碰撞到的对象应该具有 Character 组件
            Character character = collision.GetComponent<Character>();

            // 如果 Character 组件不为空，则调用 TakeDamage 方法
            if (character != null)
            {
                character.TakeDamage(new Attack { damage = damage });
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            animator.Play("Boom");
        }
    }

}
