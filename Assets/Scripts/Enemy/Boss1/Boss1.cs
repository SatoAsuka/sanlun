using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    FireBall,
    FirePillar,
    Dash,
    BeHit,
    Death,
}
public class Boss1 : MonoBehaviour
{
    Transform C_tra;
    Transform Mouth;
    Rigidbody2D C_rig;
    Animator C_ani;
    public AudioSource HitAudio;
    public AudioSource AttackAudio;
    public Animator EffectAni;//特效的播放
    public GameObject Fireball;//火球的预制体
    public GameObject FirePillar;//火柱的预制体
    public GameObject Player;//获取到玩家的位置
    public GameObject Pillar1;//平台一
    public GameObject Pillar2;//平台二

    Vector2 Initial;

    BossState state;

    public float MaxHp;
    public float Hp;

    public int MoveDamge;

    public float Speed;

    public float IdleTime;
    public float FirePillarCd;
    public float time;

    public int FireBallAttackTime;
    public int FirePillarAttackTime;

    public bool isHit;
    public bool isDead;

    void Awake()
    {
        C_tra = GetComponent<Transform>();
        C_rig = GetComponent<Rigidbody2D>();
        C_ani = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        Mouth = transform.Find("Mouth");

        Initial = C_tra.localScale;

        state = BossState.Idle;

        MaxHp = 200;
        Hp = MaxHp;

        MoveDamge = 20;

        Speed = 12;

        isDead = false;

        IdleTime = 5f;
        FirePillarCd = 20f;
        time = 1f;

        FireBallAttackTime = 3;
        FirePillarAttackTime = 7;
    }
    void Update()
    {
        CheckHp();
        switch (state)
        {
            case BossState.FireBall:
                {
                    FireBallAttack();
                    break;
                }
            case BossState.FirePillar:
                {
                    FirePillarAttack();

                    break;
                }
            case BossState.Dash:
                {
                    DashSkill();
                    break;
                }
            case BossState.Idle:
                {
                    IdleProccess();
                    break;
                }
            case BossState.BeHit:
                {
                    BeHitProccess();
                    break;
                }
            case BossState.Death:
                {
                    C_ani.Play("Death");
                    break;
                }
        }
    }
    public void FireBallAttack() //吐火球
    {
        C_ani.Play("Attack");
        FirePillarCd -= Time.deltaTime;
        if (FireBallAttackTime <= 0 && !isDead)
        {
            state = BossState.Idle;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void FireBallCreate() //生成火球(动画帧事件)
    {
        if (C_tra.localScale.x == Initial.x) // Boss 朝右
        {
            for (int i = -1; i < 5; i++)
            {
                GameObject fireball = Instantiate(Fireball, null);
                Vector3 dir = Quaternion.Euler(30, i * 15, 0) * -transform.right; // 使用 transform.right
                fireball.transform.position = Mouth.position + dir * 1.0f;
                fireball.transform.rotation = Quaternion.Euler(0, 0, i * 15);
            }
        }
        else if (C_tra.localScale.x == -Initial.x) // Boss 朝左
        {
            for (int i = -5; i < 2; i++)
            {
                GameObject fireball = Instantiate(Fireball, null);
                Vector3 dir = Quaternion.Euler(30, i * 15, 0) * transform.right; // 使用 -transform.right
                fireball.transform.position = Mouth.position + dir * 1.0f;
                fireball.transform.rotation = Quaternion.Euler(0, 0, i * 15);
            }
        }
        FireBallAttackTime -= 1;
    }

    public void DashSkill()
    {
        if (!isDead)
        {
            Dash();
            IdleTime = 5f;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void Dash()//冲撞 
    {
        if (C_tra.localScale.x == Initial.x)
        {
            C_ani.Play("Walk");
            C_rig.velocity = new Vector2(-Speed, C_rig.velocity.y);
        }
        else if (C_tra.localScale.x == -Initial.x)
        {
            C_ani.Play("Walk");
            C_rig.velocity = new Vector2(Speed, C_rig.velocity.y);
        }
    }
    public void FirePillarAttack() //火柱攻击
    {
        C_ani.Play("OtherAttack");
        //Pillar1.GetComponent<Collider2D>().enabled = false;
        //Pillar2.GetComponent<Collider2D>().enabled = false;
        FirePillarCd = 20f;
        if (FirePillarAttackTime <= 0 && !isDead)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                state = BossState.Idle;
                time = 1;
            }
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void CreateFirePillar() //生成火柱（动画帧事件）
    {
        for (int i = 0; i < 5; i++)
        {
            int r = Random.Range(-14, 14);
            GameObject firepillar = Instantiate(FirePillar, null);
            firepillar.transform.position = new Vector3(r, 6, 0);
        }
        FirePillarAttackTime -= 1;
    }
    public void IdleProccess()
    {
        C_ani.Play("Idle");
        //Pillar1.GetComponent<Collider2D>().enabled = true;
        //Pillar2.GetComponent<Collider2D>().enabled = true;
        FirePillarCd -= Time.deltaTime;
        IdleTime -= Time.deltaTime;
        if (Hp <= MaxHp / 2 && IdleTime > 0)
        {
            FireBallAttackTime = 5;
            FirePillarAttackTime = 7;
        }
        else if (Hp > MaxHp / 2 && IdleTime > 0)
        {
            FireBallAttackTime = 3;
            FirePillarAttackTime = 7;
        }
        if (IdleTime <= 0 && !isHit && !isDead)
        {
            if (FirePillarCd <= 0 && Hp <= MaxHp / 2)
            {
                state = BossState.FirePillar;
            }
            else
            {
                state = BossState.Dash;
            }
        }
        else if (isHit && !isDead)
        {
            state = BossState.BeHit;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void BeHitProccess()
    {
        C_ani.Play("BeHit");
        IdleTime -= Time.deltaTime;
        if (!isHit && !isDead)
        {
            state = BossState.Idle;
        }
        else if (isDead)
        {
            state = BossState.Death;
        }
    }
    public void BeHit(float Damge)
    {
        Hp -= Damge;
        isHit = true;
        HitAudio.Play();
        EffectAni.Play("1");
    }
    public void BeHitOver()
    {
        isHit = false;
    }
    public void CheckHp()
    {
        if (Hp <= 0)
        {
            isDead = true;
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void PlayAttackAudio()
    {
        AttackAudio.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AirWall") && state == BossState.Dash)
        {
            C_tra.localScale = new Vector3(-C_tra.localScale.x, C_tra.localScale.y, C_tra.localScale.z);
            state = BossState.FireBall;
        }
        else if (collision.collider.CompareTag("Player") && state == BossState.Dash)
        {
            Debug.Log("与Player碰撞");
            //如果Boss正在执行Dash技能，并且与被标记为“Player”的碰撞体发生了碰撞，
            //那么Boss将会对玩家造成伤害（BeHit），根据玩家的位置来确定伤害的方向。

            // 获取攻击力（damage）为火球的伤害值
            int damage = MoveDamge;

            // 碰撞到的对象应该具有 Character 组件
            Character character = collision.gameObject.GetComponent<Character>();

            // 如果 Character 组件不为空，则调用 TakeDamage 方法
            if (character != null)
            {
                character.TakeDamage(new Attack { damage = damage });
            }
        }
    }
}