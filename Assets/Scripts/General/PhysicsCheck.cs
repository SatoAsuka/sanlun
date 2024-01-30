using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //[Header("¼ì²â²ÎÊý")]
    public Vector2 bottomOffset;//½Åµ×Î»ÒÆ²îÖµ
    public float checkRaduis;//¼ì²â·¶Î§
    public LayerMask groundLayer;

    //[Header("×´Ì¬")]
    public bool isGround;

    public void Update()
    {
        Check();
    }

    public void Check()
    {  //µØÃæÅÐ¶Ï
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);//¼ì²âÊÇ·ñ´¥µØ
 
    }

    #region »æÖÆ¼ì²â·¶Î§
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);
    }
    #endregion
}


