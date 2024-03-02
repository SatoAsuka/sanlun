using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTimeCrease : MonoBehaviour
{
    private CircleCollider2D cd;
    bool Iscrease;
    void Start()
    {
        cd = GetComponent<CircleCollider2D>();
        Iscrease = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Iscrease )
        {
            PlayController.jumpMoreTimes += 1;
            Iscrease = true;
            Debug.Log("1");
        }

      
    }
    void Update()
    {
        
    }
}
