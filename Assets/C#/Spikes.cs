using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public string lvlName;
    private Rigidbody2D rig;
    [SerializeField] AudioSource audioSource;
    public AudioClip playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        audioSource.clip = playerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player.lives > 1)
                {
                    player.UpdateLives();
                    audioSource.Play();
                }
                else
                {
                    player.UpdateLives();
                    audioSource.Play();
                    GameController.Instance.ResetScore();
                }
        }
    }


}
