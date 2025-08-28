using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] AudioSource sfx;
    public AudioClip soundNextLevel; 

    public string lvlName;
    public int lvlValue;

    public void Start()
    {
        if(lvlName != "Final")
        {
            string[] eggs = lvlName.Split('_');
            int lvlNextNumber = int.Parse(eggs[1]);
            int lvlNumber = lvlNextNumber - 1;
            lvlValue = 3 * lvlNumber;
        }
    
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(lvlName != "Final")
            {
                if(StaticScore.keepValue == lvlValue)
            {
                sfx.clip = soundNextLevel;
                sfx.Play();
                StaticScore.keepValue = GameController.Instance.totalScore;
                SceneManager.LoadScene(lvlName);
            }
            else
            {
                Debug.Log("Save more Eggs!");
            }
            } 
            else
            {
                SceneManager.LoadScene("Final");
            }
            
        }
    }
}
