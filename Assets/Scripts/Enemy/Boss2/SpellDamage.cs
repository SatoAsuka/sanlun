using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    public GameObject player;
    public int damage;
    public Animator animator;
    public bool inAttacked;
    public Boss2 Boss2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Boss2 = GetComponent<Boss2>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void spell()
    {
        animator.Play("Spell");
        int Damage = damage;
        player.GetComponent<PlayerAnimation>().GetHurted(Damage);
        inAttacked = false;

    }
}
