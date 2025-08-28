using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScore : MonoBehaviour 
{
    public static int keepValue = 0;

    private void Awake()
    {
        // Impede que o objeto seja destruído ao mudar de cena
        DontDestroyOnLoad(gameObject);
    }
}