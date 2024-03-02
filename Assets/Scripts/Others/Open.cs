using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject Key4;
    private void Update()
    {
        if (Key1 == null && Key2 == null && Key3 == null && Key4 == null)
        {
            Destroy(gameObject);
        }
    }
}
