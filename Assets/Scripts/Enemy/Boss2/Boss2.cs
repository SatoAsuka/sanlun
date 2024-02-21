using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public enum Boss2State
{
    Idle,
    Walk,
    Walk2,
    Attack,
    Cast,
    Hurt,
    Death,
}


public class Boss2 : MonoBehaviour
{
    Transform boss_trans;
    Rigidbody2D boss_rb;
    Animator boss_ani;
    public GameObject player;


    public Boss2State state;

    public float HP;
    public float waitTime;
    public float currTime;
    public float findDis;
    public float dis;
    public float speed;

    public bool isFound;
    

    private void Awake()
    {
        player = GameObject.Find("Player");
        boss_rb = GetComponent<Rigidbody2D>();
        boss_ani = GetComponent<Animator>();
        boss_trans = GetComponent<Transform>();

        isFound = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dis = Mathf.Abs(boss_trans.position.x - player.transform.position.x);
        
        switch (state) 
        {
            case Boss2State.Idle:
                {
                    Idle();
                    break;
                }
            case Boss2State.Walk:
                {
                    Walk();
                    break;
                }
            case Boss2State.Walk2:
                {
                    Walk2();
                    break;
                }
            case Boss2State.Hurt: 
                {
                    boss_ani.Play("Hurt");
                    break;
                }
            case Boss2State.Death: 
                {
                    Death();
                    break;
                }
            case Boss2State.Attack: 
                {
                    boss_ani.Play("Attack");
                    break;
                }
            case Boss2State.Cast: 
                {
                    boss_ani.Play("Cast");
                    break;
                }
        }
    }

    private void Death()
    {
        boss_ani.Play("Death");
        if (HP == 0)
        {

        }
        else
        {
            int boss_dir = (int)(boss_trans.position.x - player.transform.position.x);
            if (boss_dir > 0)
                boss_dir = 1;
            else boss_dir = -1;

            boss_rb.velocity = new Vector2(boss_dir * speed * Time.deltaTime, boss_rb.velocity.y);
            transform.localScale = new Vector3(boss_dir, 1, 1);
        }

    }

    private void Walk2()
    {
        boss_ani.Play("Walk2");
        int boss_dir = (int)(boss_trans.position.x - player.transform.position.x);
        if (boss_dir > 0)
            boss_dir = 1;
        else boss_dir = -1;

        boss_rb.velocity = new Vector2(boss_dir * speed * Time.deltaTime, boss_rb.velocity.y);
        transform.localScale = new Vector3(boss_dir, 1, 1);

        if (dis > findDis)
        {
            int nub = UnityEngine.Random.Range(3, 5);
            if(nub == 3)
                state = Boss2State.Cast;
            if(nub == 4)
                state = Boss2State.Walk;
        }
    }

    private void Walk()
    {
        boss_ani.Play("Walk");
        int boss_dir = (int)(boss_trans.position.x - player.transform.position.x);
        if (boss_dir > 0)
            boss_dir = 1;
        else boss_dir = -1;

        boss_rb.velocity = new Vector2(-1 * boss_dir * speed * Time.deltaTime, boss_rb.velocity.y);
        transform.localScale = new Vector3(boss_dir, 1, 1);
    }

    private void Idle()
    {
        boss_ani.Play("Idle");
        OnFind();
    }

    private void OnFind()
    {
        if(dis <= findDis)
        {
            int nub = UnityEngine.Random.Range(3, 5);
            if(nub == 3)
                state = Boss2State.Walk;
            else if(nub == 4)
                state = Boss2State.Walk2;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(state != Boss2State.Death && state != Boss2State.Cast && state != Boss2State.Hurt)
            state = Boss2State.Attack;
    }
}
