using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("��������")]
    public float maxHealth;//���Ѫ��
    public float curentHealth;//ĿǰѪ��
    public bool isBoss;

    [Header("�����޵�")]
    public float invulnerableDuration;//�趨�޵�ʱ��
    private float invulnerableCounter;//�޵�ʱ�䣬���ڼ�ʱ
    public bool invulnerable;
    public UnityEvent<Character> OnHealthChange;
    #region �¼��ϼ�
    public UnityEvent<Transform> OnTakeDamage;//�趨�����¼�
    public UnityEvent OnDie;//�趨�����¼������贫���κβ���
    #endregion
    private void Start()
    {
        curentHealth = maxHealth;
        OnHealthChange?.Invoke(this);
    }

    private void Update()
    {
        #region �޵�ʱ���ʱ
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

    public void TakeDamage(Attack attacker)//����
    {
        if (invulnerable)
            return;

        if (curentHealth - attacker.damage > 0)
        {
            curentHealth -= attacker.damage;
            TriggerInvulnerable();
            //ִ������
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {

        }

        OnHealthChange?.Invoke(this);

    }
    #region �޵�״̬
    private void TriggerInvulnerable()
    {
        if (!invulnerable)
        {
            invulnerable = true;//�����޵�
            invulnerableCounter = invulnerableDuration;//�����޵�ʱ��
        }
    }
    #endregion
}
    

