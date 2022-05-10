using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKunai : MonoBehaviour
{
    public float speedX = 15;
    public float ac = 1f;
    Rigidbody2D kunai;

    public Transform playerTransform;

    void Start()
    {
        kunai = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 toPlayer = playerTransform.position - transform.position;
        toPlayer.Normalize();
        toPlayer *= ac;

        kunai.velocity = kunai.velocity + toPlayer*Time.deltaTime;
        //Destroy(gameObject, 5f);

        ac += Time.deltaTime * 2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            Debug.Log("Destroy");
           // Destroy(gameObject, 0f);
        }
        
    }
}
