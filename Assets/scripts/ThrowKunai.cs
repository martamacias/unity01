using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKunai : MonoBehaviour
{
    public float speedX = 10f;
    const float ac = 100f;
    Rigidbody2D kunai;
    float count = 0f;
    float timeToStartCounter = 0f;
    const float maxTime = 1f;
    const float timeStartCounting = 0.5f;

    public Transform playerTransform;

    void Start()
    {
        kunai = GetComponent<Rigidbody2D>();
        kunai.velocity = transform.right * speedX;
    }

    void Update()
    {
        Vector2 toPlayer = playerTransform.position - transform.position;
        toPlayer.Normalize();

        float magn = kunai.velocity.magnitude;

        var steeringForce = (toPlayer.normalized * ac - kunai.velocity.normalized);

        var newVel = (kunai.velocity + steeringForce * Time.deltaTime).normalized * magn;
        var finalVel = toPlayer * newVel.magnitude;

        if (timeToStartCounter > timeStartCounting)
        {
            count += Time.deltaTime;
            float t = count / maxTime;
            kunai.velocity = Vector2.Lerp(newVel, finalVel, t).normalized * magn;
        }
        else
        {
            kunai.velocity = newVel;
            timeToStartCounter += Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject, 0f);
        }
        
    }
}
