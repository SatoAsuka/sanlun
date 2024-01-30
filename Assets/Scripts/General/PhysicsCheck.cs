using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //[Header("������")]
    public Vector2 bottomOffset;//�ŵ�λ�Ʋ�ֵ
    public float checkRaduis;//��ⷶΧ
    public LayerMask groundLayer;

    //[Header("״̬")]
    public bool isGround;

    public void Update()
    {
        Check();
    }

    public void Check()
    {  //�����ж�
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);//����Ƿ񴥵�
 
    }

    #region ���Ƽ�ⷶΧ
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
    #endregion
}


