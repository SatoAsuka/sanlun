using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//访问类，角色控制需要


public class PlayerMovements : MonoBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpSpeed;
        [Range(0, .3f)]
        [SerializeField] private float checkRadius = .2f;
        new private Rigidbody2D rigidbody;
        private Animator animator;
        public PlayerInputControl inputControl;

        private Vector2 inputX;
        [SerializeField] private bool isGround = true;
        [SerializeField] private LayerMask layer;

        

        private void Awake()
        {
            inputControl = new PlayerInputControl();

            inputControl.GamePlay.Jump.started += Jump;
        }


        private void OnEnable()//物体启动时，inputControl也启动
        {
            inputControl.Enable();
        }

        private void OnDisable()//物体关闭时，inputControl也关闭
        {
            inputControl.Disable();
        }
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            inputX = inputControl.GamePlay.Move.ReadValue<Vector2>(); ;
            isGround = Physics2D.OverlapCircle(transform.position, checkRadius, layer);

            Move();
            Flip();
        }

        private void Flip()
        {
            if (inputX.x < -1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (inputX.x > 1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (isGround)
            {
                rigidbody.velocity = new Vector2(0, jumpSpeed);
                animator.SetTrigger("Jump");
            }
        }

        private void Move()
        {
            rigidbody.velocity = new Vector2(inputX.x * moveSpeed, rigidbody.velocity.y);

            animator.SetBool("isGround", isGround);
            animator.SetFloat("Horizontal", rigidbody.velocity.x);
            animator.SetFloat("Vertical", rigidbody.velocity.y);
        }
    }
}