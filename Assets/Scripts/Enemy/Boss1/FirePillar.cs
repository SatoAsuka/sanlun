using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    Animator ani;
    AudioSource music;
    public float Speed;
    public int Damge;
    public bool IsBoom;
    void Awake()
    {
        ani = GetComponent<Animator>();
        music = GetComponent<AudioSource>();

        Speed = 5;
        Damge = 15;
        IsBoom = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (!IsBoom) 
        {
            Move();
        }
    }
    public void Move() 
    {
        transform.position += Speed *Vector3.down * Time.deltaTime;
    }
    public void ChangePosition() 
    {
        transform.position = new Vector3(transform.position.x, -3.35f, 0);
    }
    public void Destroy() 
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            IsBoom = true;
            transform.position = new Vector3(transform.position.x, -1.6f, 0);
            ani.Play("boom");
            music.Play();
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("boom")) 
            {
                music.Play();
            }
        }
        else if (collision.CompareTag("Player")) 
        {
            IsBoom = true;
            transform.position = new Vector3(transform.position.x, -1.6f, 0);
            ani.Play("boom");
            music.Play();

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
    }
}
