using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("基本属性")]
    public int damage;
    public float attackRange;
    public float attackRate;

    private void OnTriggerStay2D(Collider2D other)//触碰扣血
    {
        other.GetComponent<Character>()?.TakeDamage(this);//检测对方身上是否有Character组件，若有，造成伤害
    }
}
