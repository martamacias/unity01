using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKunai : MonoBehaviour
{
    public float speedX = 15;
    Rigidbody2D kunai;

    void Start()
    {
        kunai = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        kunai.velocity = transform.right * speedX;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            Debug.Log("Destroy");
            Destroy(gameObject, 0f);
        }
        
    }
}
