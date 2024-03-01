using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int Boss3Damage;
    private BoxCollider2D Bc;
    // Start is called before the first frame update
    void Start()
    {
        Bc= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other ) 
    {
        if (other.CompareTag("Boss3"))
        {
            other.GetComponent<Boss3>().GetHurted(Boss3Damage);
        }
    }
    void Update()
    {
        
    }
}
