using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//访问类，角色控制需要

public class PlayController : MonoBehaviour
{

    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    private Rigidbody2D rb;
    private PhysicsCheck physicscheck;
    private PlayerAnimation playerAnimation;

    //[Header("基本参数")]
    public float speed;
    public float jumpForce;
    public float dashForce;
    public int jumpMoreTimes;
    public int curentJumpTimes;
    public bool isAttack;
    public bool isDash;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicscheck = GetComponent<PhysicsCheck>();
        playerAnimation = GetComponent<PlayerAnimation>();

        inputControl = new PlayerInputControl();

        inputControl.GamePlay.Jump.started += Jump;
        inputControl.GamePlay.Attack.started += PlayerAttack;
        inputControl.GamePlay.Dash.started += PlayerDash;
    }

    // Start is called before the first frame update
    void Start()
    {
        curentJumpTimes = 0;
    }

    private void OnEnable()//物体启动时，inputControl也启动
    {
        inputControl.Enable();
    }

    private void OnDisable()//物体关闭时，inputControl也关闭
    {
        inputControl.Disable();
    }

    private void Update()// Update is called once per frame
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        if(!isAttack)
            Move();
        JumpMore();

    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//人物移动

        #region 人物翻转
        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x < 0)
        {
            faceDir = -1;
        }
        if (inputDirection.x > 0)
        {
            faceDir = 1;
        }
        transform.localScale = new Vector3(faceDir, 1, 1);
        #endregion
    }

    #region jump相关
    private void Jump(InputAction.CallbackContext context)
    {
        if (curentJumpTimes < jumpMoreTimes)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            curentJumpTimes += 1;
        }
    }

    private void JumpMore()//第一次起跳检测过快，导致跳跃次数刷新
    {
        if(physicscheck.isGround && curentJumpTimes != 0) 
            curentJumpTimes = 0;
    }
    #endregion

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        playerAnimation.PlayerAttack();
        isAttack = true;
    }

    private void PlayerDash(InputAction.CallbackContext context)
    {   
        playerAnimation.PlayerDash();
        isDash = true;
        rb.AddForce(transform.right * dashForce, ForceMode2D.Impulse);
    }
}

    
