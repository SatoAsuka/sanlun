using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAttack : MonoBehaviour
{
    private CircleCollider2D cd;
    bool canAttack;
    void Start()
    {
        cd = GetComponent<CircleCollider2D>();
        canAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canAttack)
        {
            PlayController.canatack = true;
            Debug.Log("1");
        }
    }
}
