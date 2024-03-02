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
    public GameObject Player;
    public GameObject Home;

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
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));//ˮƽ�ٶȸ�ֵ
        anim.SetFloat("velocityY", rb.velocity.y);//��ֱ�ٶȸ�ֵ
        anim.SetBool("isGround", physicsCheck.isGround);//���Ƿ񴥵ص���
        anim.SetBool("isAttack",playController.isAttack);//�Ƿ񹥻�
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
    public void ReLive()
    {
        Player.transform.position=Home.transform.position;
        Time.timeScale = 1.0f;
        anim.SetBool("Die", false);
        HealthBar.HealthCurrent = HealthBar.HealthMax = 30;
    }
}
