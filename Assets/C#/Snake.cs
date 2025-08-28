using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;
    public AudioClip death;
    public AudioClip playerDeath;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    public string lvlName;

    private Rigidbody2D rig;
    private Animator anim;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource.clip = death;
        audioSource2.clip = playerDeath;
    }
    
bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            if (height > 0 && !playerDestroyed)
            {
                audioSource.Play();
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                anim.SetTrigger("die");
                Destroy(gameObject, 0.25f);
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                Player player = col.gameObject.GetComponent<Player>();
                if(player.lives > 1)
                {
                    player.UpdateLives();
                    audioSource2.Play();
                }
                else if (player.lives == 1 && !playerDestroyed)
                {
                player.UpdateLives();
                audioSource2.Play();
                playerDestroyed = true;
                GameController.Instance.ResetScore();
                }
            }
        }
    }

    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
            if(groundInfo.collider == false)
            {
                if(movingRight == true)
                {
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    movingRight = false;
                } else 
                {
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    movingRight = true;
                }

            }
    }
}


