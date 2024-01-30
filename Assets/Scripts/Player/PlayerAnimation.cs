using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private PlayController playController;

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
}
