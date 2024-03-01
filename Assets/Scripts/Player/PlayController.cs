using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//�����࣬��ɫ������Ҫ

public class PlayController : MonoBehaviour
{

    public PlayerInputControl inputControl;
    public Vector2 inputDirection;
    public Animator player_ani;
    private Rigidbody2D rb;
    private PhysicsCheck physicscheck;
    private PlayerAnimation playerAnimation;
    private Character character;
    

    //[Header("��������")]
    public float speed;
    public float jumpForce;
    public float dashForce;
    public static int jumpMoreTimes;
    public int curentJumpTimes;
    public bool isAttack;
    public bool isDash;
    public static bool canatack;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicscheck = GetComponent<PhysicsCheck>();
        playerAnimation = GetComponent<PlayerAnimation>();
        character = GetComponent<Character>();
        player_ani = GetComponent<Animator>();

        inputControl = new PlayerInputControl();

        inputControl.GamePlay.Jump.started += Jump;
        inputControl.GamePlay.Attack.started += PlayerAttack;
        inputControl.GamePlay.Dash.started += PlayerDash;
    }

    // Start is called before the first frame update
    void Start()
    {
        canatack = true;
        jumpMoreTimes = 1;
        curentJumpTimes = 0;
    }

    private void OnEnable()//��������ʱ��inputControlҲ����
    {
        inputControl.Enable();
    }

    private void OnDisable()//����ر�ʱ��inputControlҲ�ر�
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
        if(!isDash)
            rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rb.velocity.y);//�����ƶ�

        #region ���﷭ת
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

    #region jump���
    private void Jump(InputAction.CallbackContext context)
    {
        if (curentJumpTimes < jumpMoreTimes)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            curentJumpTimes += 1;
        }
    }

    private void JumpMore()//��һ�����������죬������Ծ����ˢ��
    {
        if(physicscheck.isGround && curentJumpTimes != 0) 
            curentJumpTimes = 0;
    }
    #endregion

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        if (canatack)
        {
            playerAnimation.PlayerAttack();
            isAttack = true;
        }
    }

    private void PlayerDash(InputAction.CallbackContext context)
    {   
        playerAnimation.PlayerDash();
        isDash = true;
        character.TriggerInvulnerable();
        rb.AddForce((int)transform.localScale.x * transform.right * dashForce, ForceMode2D.Impulse);
    }

    public void PlayerHurt()
    {
        player_ani.Play("Death");
    }
}

    
