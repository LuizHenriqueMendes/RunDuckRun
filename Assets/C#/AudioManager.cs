using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


}
