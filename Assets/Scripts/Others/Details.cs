using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Details : MonoBehaviour
{
    public GameObject TouchKeyCode;
    public GameObject Botton;
    private bool IsNear;
    private CircleCollider2D Trigger;
    void Start()
    {
        Trigger = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        StartUI();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchKeyCode.SetActive(true);
            IsNear = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TouchKeyCode.SetActive(false);
            IsNear = false;

        }
    }
    void StartUI()
    {
        if (IsNear && Input.GetKeyDown(KeyCode.E))
        {
            Botton.SetActive(true);

        }
        if (!IsNear)
        {
            Botton.SetActive(false);
        }

    }
}