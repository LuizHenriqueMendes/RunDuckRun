using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CAVE : MonoBehaviour
{

    // [SerializeField]
    // private float speed;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    public string lvlName;

    private Rigidbody2D rig;
    private Animator anim;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;

    [SerializeField]
    private LayerMask layer;

    private float jumpForce;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    


    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }
bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            if (height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                // anim.SetTrigger("die");
                Destroy(gameObject, 0.1f);
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                playerDestroyed = true;
               // GameController.Instance.ShowGameOver();
                Destroy(col.gameObject);
                SceneManager.LoadScene(lvlName);

            }
        }
    }


//     public float speed;
//     public float moveTime;

//     private bool dirRight = true;
//     private float timer;

//   void Update()
//   {
//       if(dirRight)
//       {
//         transform.Translate(Vector2.right * speed * Time.deltaTime);
//      //   transform.eulerAngles = new Vector3(0f, 0f, 0f);
//       }
//       else
//       {
//           transform.Translate(Vector2.left * speed * Time.deltaTime);
//          // transform.eulerAngles = new Vector3(0f, 180f, 0f);
//       }
  

//     timer += Time.deltaTime;
    
//     if(timer >= moveTime)
//     {
//         dirRight = !dirRight;
//         timer = 0f;
//     }
//   }
//   }


public float speed;
public float distance;
private bool movingRight = true;


// void Update(){

//         transform.Translate(Vector2.right * speed * Time.deltaTime);
//         RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
//         if(groundInfo.collider == false){
//             if(movingRight == true){
//                 transform.eulerAngles = new Vector3(0f, 180f, 0f);
//                 movingRight = false;
//             } else {
//                 transform.eulerAngles = new Vector3(0f, 0f, 0f);
//                 movingRight = true;
//             }

//         }
// }
}

