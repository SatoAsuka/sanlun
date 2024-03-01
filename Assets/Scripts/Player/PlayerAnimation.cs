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
    bool isHurt;

    private void Start()
    {
  
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
            anim.SetBool("Hurt", true);
            PlayerHealth -= Damage;
    }
    void Die()
    {
        if (PlayerHealth <= 0)
        {
            anim.SetBool("Die", true);
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
}
