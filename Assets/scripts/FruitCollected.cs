using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public Text scoreText;
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.2f);
            clip.Play();
            PlayerMoveJoystic.score += 1;
            scoreText.text = PlayerMoveJoystic.score + "/2";
        }
    }
}
