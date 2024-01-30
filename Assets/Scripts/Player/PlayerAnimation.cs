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
}
