using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("��������")]
    public int damage;
    public float attackRange;
    public float attackRate;

    private void OnTriggerStay2D(Collider2D other)//������Ѫ
    {
        other.GetComponent<Character>()?.TakeDamage(this);//���Է������Ƿ���Character��������У�����˺�
    }
}
