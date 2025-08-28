// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Snake : MonoBehaviour
// {


//     public float Speed;
//     public string lvlName;

//     public Animator anim;

//     private Rigidbody2D rig;
//     public CircleCollider2D circle;
//     public BoxCollider2D box;
//     private bool colliding;

//     // Start is called before the first frame update
//     void Start()
//     {
//     rig = GetComponent<Rigidbody2D>();
//     anim = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
//     void OnCollisionEnter2D(Collision2D collision)
//     {

//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
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

    // [SerializeField]
    // private LayerMask layer;

    // private float jumpForce;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    


//     void Update()
//     {
//         rig.velocity = new Vector2(speed, rig.velocity.y);

//         colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

//         if (colliding)
//         {
//             transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
//             speed *= -1f;
//         }
//     }
bool playerDestroyed;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y;
            if (height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                anim.SetTrigger("die");
                Destroy(gameObject, 0.25f);
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

void Update(){

        transform.Translate(Vector2.right * speed * Time.deltaTime);

}
}

