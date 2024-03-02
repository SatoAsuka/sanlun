using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private PlayController playController;
    public int PlayerHealth;
    public bool IsDash;
    private ScreenFlash sf;
    bool isdie;

    private void Start()
    { 
        IsDash = false;
        sf=GetComponent<ScreenFlash>();
        HealthBar.HealthMax = PlayerHealth;
        HealthBar.HealthCurrent = PlayerHealth;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        playController = GetComponent<PlayController>();
    }

    private void Update()
    {
        SetAnimation();
        Die();
    }

    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));//水平速度赋值
        anim.SetFloat("velocityY", rb.velocity.y);//竖直速度赋值
        anim.SetBool("isGround", physicsCheck.isGround);//将是否触地导入
        anim.SetBool("isAttack",playController.isAttack);//是否攻击
        anim.SetBool("isDash", playController.isDash);
    }

    public void PlayerAttack()
    {
            anim.SetTrigger("attack");      
    }

    public void PlayerDash()
    {
        anim.SetTrigger("dash");
    }
    public void GetHurted(int Damage)
    {
        if (!IsDash&&!isdie)
        {
            sf.FlashScreen();
            anim.SetBool("Hurt", true);
            PlayerHealth -= Damage;
            HealthBar.HealthCurrent = PlayerHealth;
        }
    }
    void Die()
    {
        if (PlayerHealth <= 0)
        {
            anim.SetBool("Die", true);
            isdie = true;
        }
    }
    void DieAnim()
    {
        Time.timeScale = 0.4f;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    public void Hurtover()
    {
            anim.SetBool("Hurt", false);    
    }
    void godash()
    {
        IsDash = true;
    }
    void dashover()
    {
        IsDash = false;
    }
}
