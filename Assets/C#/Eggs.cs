
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


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.Instance.totalScore += Score;
            GameController.Instance.UpdateScoreText();

            Destroy(gameObject, 0.4f);

        }   

    }



}




