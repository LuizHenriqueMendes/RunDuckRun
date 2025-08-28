using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig;
    public Animator anim;
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public int lives = 3;

    [SerializeField] AudioSource audioSource;
    public AudioClip jumpSfx;

    private Vector3 initialPosition; 

    public Sprite[] lifeSprites;
    private SpriteRenderer spriteRenderer;
    public Image livesImage;
   // public GameObject gameOver;
//    public GameObject gameOverBtn;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource.clip = jumpSfx;
        initialPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLifeSprite();

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    public void UpdateLives()
    {
        lives -= 1; 
        UpdateLifeSprite();

        if(lives > 0)
        {
            transform.position = initialPosition;
        }
        if(lives <= 0)
        {
            SceneManager.LoadScene("lvl_1");
        }
    }

void UpdateLifeSprite()
    {
        if (lives >= 0 && lives < lifeSprites.Length)
        {
            spriteRenderer.sprite = lifeSprites[lives];
        }

        // Atualiza o sprite da UI de vida
        if (livesImage != null && lives >= 0 && lives < lifeSprites.Length)
        {
            livesImage.sprite = lifeSprites[lives];
        }
      //  if (lives < 1)
      //   {
      //      gameOver.SetActive(true);
      //      gameOverBtn.SetActive(true);
      //  }
    }

    void Move()
    {

        float movement = Input.GetAxis("Horizontal");
        
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if(movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }
        void Jump()
        {
            if(Input.GetButtonDown("Jump"))
            {
                if(!isJumping)
                {
                    audioSource.Play();
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                }
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == 8)
            {
                isJumping = false;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
           
           if (collision.gameObject.layer == 8)
           {
            isJumping = true;
           }        
        }
}
