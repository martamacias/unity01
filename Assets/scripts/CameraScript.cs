using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    public float forward;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        /*if (Input.GetKey(KeyCode.D)) //derecha
        {
            playerPos = new Vector3(playerPos.x + forward, playerPos.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A)) //izquierda
        {
            playerPos = new Vector3(playerPos.x - forward, playerPos.y, transform.position.z);
        }*/
        transform.position = Vector3.Lerp(transform.position, playerPos, smoothing * Time.deltaTime);
    }
}
