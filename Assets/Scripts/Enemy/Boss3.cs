using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Anim;
    private BoxCollider2D box;
    public GameObject fireball;
    public GameObject fireball2;
    private Animator anim;
    public int EnemyHealth;
    void Start()
    { 
        Anim=GetComponent<Animator>();
        box= GetComponent<BoxCollider2D>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Anim.SetTrigger("attack");
            Debug.Log("2");
        }
        
    }
    public void creatfireball()
    { 
            for (int i = 0; i < 4; i++)
            {
                GameObject Fireball = Instantiate(fireball, null);
                Fireball.transform.position -= new Vector3(0, 2f * i, 0);
            }
        for (int i = 0; i < 6; i++)
        {
            int r = Random.Range(-105, -85);//这里的范围是平台的长度
            GameObject firepillar = Instantiate(fireball2, null);
            firepillar.transform.position = new Vector3(r, -25, 0);
        }
        Debug.Log("1");
    }
    public void GetHurted(int Damage)
    {
        anim.SetBool("Hurt", true);
        EnemyHealth -= Damage;
    }
    void Die()
    {
        if (EnemyHealth <= 0)
        {
            anim.SetBool("Die", true);
        }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    public void Hurtover()
    {
        anim.SetBool("Hurt", false);
    }
}
