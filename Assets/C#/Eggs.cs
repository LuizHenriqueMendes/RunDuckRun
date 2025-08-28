using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eggs : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;
    public int Score;
    [SerializeField] AudioSource sfx;
    public AudioClip soundCollected;

    void Start()
    {
        sfx.clip = soundCollected;
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sfx.Play();
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            GameController.Instance.AddScore(Score);
            Destroy(gameObject, 0.4f);
        }   
    }
}
