﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckPoint : MonoBehaviour
// {
//     public string lvlName;
//     private void OnCollsionEnter2D(Collision2D collision)
//     {
//         if(collision.gameObject.tag == "Player")
//         {
//             SceneManager.LoadScene(lvlName);
//         }
//     }


// }
{
    public string lvlName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}

