using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("基本属性")]
    public float maxHealth;//最大血量
    public float curentHealth;//目前血量
    public bool isBoss;

    [Header("受伤无敌")]
    public float invulnerableDuration;//设定无敌时间
    private float invulnerableCounter;//无敌时间，用于计时
    public bool invulnerable;
    public UnityEvent<Character> OnHealthChange;
    #region 事件合集
    public UnityEvent<Transform> OnTakeDamage;//设定受伤事件
    public UnityEvent OnDie;//设定死亡事件，不需传递任何参数
    #endregion
    private void Start()
    {
        curentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }

    private void Update()
    {
        #region 无敌时间计时
        if (invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
        #endregion

        if (transform.position.y <= -100)
        {
            curentHealth -= curentHealth;
            OnDie?.Invoke();
        }
    }

    public void TakeDamage(Attack attacker)//受伤
    {
        if (invulnerable)
            return;

        if (curentHealth - attacker.damage > 0)
        {
            curentHealth -= attacker.damage;
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {

        }

        OnHealthChange?.Invoke(this);

    }
    #region 无敌状态
    private void TriggerInvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;//启动无敌
            invulnerableCounter = invulnerableDuration;//设置无敌时间
        }
    }
    #endregion
}
    

