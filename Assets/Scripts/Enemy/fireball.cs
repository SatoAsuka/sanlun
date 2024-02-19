using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float destroytime;
    private float time;
    private Transform Trans;
    void Start()
    {
        Trans=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        time += Time.deltaTime;
        if(time > destroytime)
        {
            Destroy(gameObject);
            time = 0;
        }
        
        
    }
    private void move()
    {
        Trans.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

}
