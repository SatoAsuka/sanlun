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
    void Start()
    { 
        Anim=GetComponent<Animator>();
        box= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        
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
        for (int i = 0; i < 3; i++)
        {
            GameObject Fireball = Instantiate(fireball, null);
            Fireball.transform.position -= new Vector3(0, 2f*i, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            int r = Random.Range(-7, 3);//这里的范围是平台的长度
            GameObject firepillar = Instantiate(fireball2, null);
            firepillar.transform.position = new Vector3(r, 3, 0);
        }
        Debug.Log("1");
    }
}
