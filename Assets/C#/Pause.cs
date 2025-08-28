using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Paused()
    {
        Time.timeScale = 0; 
    }

    public void Playing()
    {
        Time.timeScale = 1;
    }

}
