using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject Destination;
    public GameObject Player;
    private CircleCollider2D Cd;
    public bool isnear;
    public float time;
    // Start is called before the first frame update
    private void Start()
    {
        Cd = GetComponent<CircleCollider2D>();
        time = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isnear = true;
               Go();
        }
    }
    private void Go()
    {
        if (isnear)
        {
            Debug.Log("1");
            Player.transform.position = Destination.transform.position;
        }
    }
}
