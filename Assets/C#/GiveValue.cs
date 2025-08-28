using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveValue : MonoBehaviour
{
    [SerializeField] Text score;

    void Start()
    {
        // Não é necessário checar se o valor é null, pois `int` nunca será null.
        score.text = StaticScore.keepValue.ToString();
    }
}
